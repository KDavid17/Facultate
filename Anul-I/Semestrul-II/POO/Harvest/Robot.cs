using System;
using System.Threading;

namespace Harvest
{
    public class Robot
    {
        Random rnd = new Random();
        private static bool startMenu = false;
        private bool consoleShutDown = false;
        private bool initialised = false;
        private bool boot = false;
        private bool travel = false;
        private bool status = false;
        private bool outcome;
        private static int rows = -1;
        private static int time = 5;
        private int health;
        private int shield;
        private int damageMin, damageMax;
        private int currentTarget = 0, numberOfHostiles;
        private double odds;
        private World targetWorld;
        private static Robot chosenClass;
        private static long[,] lookup = new long[101, 1001];
        private string[] harvestedWorlds = { "", "0", "0", "0" };

        public bool ConsoleShutDown { get { return consoleShutDown; } }
        public int Health { get { return health; } }
        public int Shield { get { return shield; } }
        public World TargetWorld { get { return targetWorld; } }
        public Robot ChosenClass { get { return chosenClass; } }

        public class Bane : Robot
        {
            public Bane()
            {
                initialised = true;
                health = 100;
                shield = 50;
                damageMin = 1;
                damageMax = 60;
            }
            public override string ToString()
            {
                return "Bane";
            }
        }

        public class Cleaner : Robot
        {
            public Cleaner()
            {
                initialised = true;
                health = 75;
                shield = 50;
                damageMin = 1;
                damageMax = 75;
            }

            public override string ToString()
            {
                return "Cleaner";
            }
        }

        public class Daredevil : Robot
        {
            public Daredevil()
            {
                initialised = true;
                health = 50;
                shield = 50;
                damageMin = 1;
                damageMax = 100;
            }

            public override string ToString()
            {
                return "Daredevil";
            }
        }

        private void InitiateOutcome(int choice)
        {
            if (choice == 1)
            {
                PrintWithRepetition($"[{ChosenClass}] Engaging target");

                if (outcome == true)
                {
                    PrintWithPause($"[{ChosenClass}] Engage: ", "Succsseful");
                    Print($"[{ChosenClass}] The amount of hostiles eliminated: {numberOfHostiles}");

                    TargetWorld.Population -= numberOfHostiles;
                    TargetWorld.Targets[currentTarget].Amount -= numberOfHostiles;

                    if (rnd.Next(0, 2) == 1)
                    {
                        Print($"[{ChosenClass}] This unit has gained 5 Health");

                        ChosenClass.health += 5;
                    }
                }
                else
                {
                    int amountEliminated = (int)(odds / 100 * numberOfHostiles);

                    PrintWithPause($"[{ChosenClass}] Engage: ", "Unsuccsseful");
                    Print($"[{ChosenClass}] The amount of hostiles eliminated: {amountEliminated}");

                    TargetWorld.Population -= amountEliminated;
                    TargetWorld.Targets[currentTarget].Amount -= amountEliminated;

                    Print($"[{ChosenClass}] This unit has lost 15 Health");

                    ChosenClass.health -= 15;

                    if (ChosenClass.Health <= 0)
                    {
                        consoleShutDown = true;
                        status = false;

                        Print($"[{ChosenClass}] This unit has ran out of health");
                        ShutDownRobot();
                        Print("This unit has been eliminated");
                        Print("Mission: Failed");
                        PrintWithRepetition("Console shutting down");
                    }
                    else
                    {
                        PrintWithRepetition($"[{ChosenClass}] Retreating");
                        Print($"[{ChosenClass}] This unit is safe for now");
                        Print($"[{ChosenClass}] Scanners indicate hostile life forms are searching for this unit");
                    }
                }

                if (TargetWorld.Targets[currentTarget].Amount == 0)
                {
                    Print($"[{ChosenClass}] All {TargetWorld.Targets[currentTarget]} have been harvested");
                    Print($"[{ChosenClass}] Reward: + 15 Health");
                    ChosenClass.health += 15;

                    currentTarget++;
                }
            }
            else
            {
                if (rnd.Next(0, 2) == 1)
                {
                    Print($"[{ChosenClass}] This unit has lost 5 Health");

                    ChosenClass.health -= 5;
                }

                if (ChosenClass.Health <= 0)
                {
                    consoleShutDown = true;
                    status = false;

                    Print($"[{ChosenClass}] This unit has ran out of health");
                    ShutDownRobot();
                    Print("This unit has been eliminated");
                    Print("Mission: Failed");
                    PrintWithRepetition("Console shutting down");
                }
                else
                {
                    PrintWithRepetition($"[{ChosenClass}] Retreating");
                    Print($"[{ChosenClass}] This unit is safe for now");
                    Print($"[{ChosenClass}] Scanners indicate hostile life forms are searching for this unit");
                }
            }
        }

        private void CalculateOdds(Target target)
        {
            long result = 0;
            int damageDifference = ChosenClass.damageMax - ChosenClass.damageMin + 1;
            double enemyHealth = numberOfHostiles * target.Hitpoints;
            double enemyDamage = numberOfHostiles * target.Damage;
            int numberOfAttacksPossible = (int)((ChosenClass.Health + ChosenClass.Shield) / enemyDamage);

            if ((ChosenClass.Health + ChosenClass.Shield) % enemyDamage != 0)
            {
                numberOfAttacksPossible++;
            }

            for (int i = 1; i <= (int)enemyHealth - (numberOfAttacksPossible * ChosenClass.damageMin); i++)
            {
                result += CountPosibilities(numberOfAttacksPossible, damageDifference, i);
            }

            odds = 100 - ((double)result) * 100 / Math.Pow(damageDifference, numberOfAttacksPossible);

            int sum = 0;

            for (int i = 0; i < numberOfAttacksPossible; i++)
            {
                sum += rnd.Next(ChosenClass.damageMin, ChosenClass.damageMax + 1);
            }

            if (sum >= enemyHealth)
            {
                outcome = true;
            }
            else
            {
                outcome = false;
            }
        }

        private void GenerateScenario(Target target)
        {
            int minNumberOfKM = 2, maxNumberOfKM = 25;
            int minNumberOfHostiles, maxNumberOfHostiles;

            Print($"[{ChosenClass}] Current target: {target}");
            Print($"[{ChosenClass}] Distance between {target} and this unit: {rnd.Next(minNumberOfKM, maxNumberOfKM)} km.");

            if (target.ToString() == "Humans")
            {
                minNumberOfHostiles = 300000;
                maxNumberOfHostiles = 600000;

                if (target.Amount > maxNumberOfHostiles)
                {
                    Print($"[{ChosenClass}] Number of hostiles: {numberOfHostiles = rnd.Next(minNumberOfHostiles, maxNumberOfHostiles)}");
                }
                else if (target.Amount > minNumberOfHostiles)
                {
                    maxNumberOfHostiles = (int)target.Amount;

                    Print($"[{ChosenClass}] Number of hostiles: {numberOfHostiles = rnd.Next(minNumberOfHostiles, maxNumberOfHostiles)}");
                }
                else if (target.Amount < minNumberOfHostiles)
                {
                    maxNumberOfHostiles = (int)target.Amount;

                    Print($"[{ChosenClass}] Number of hostiles: {numberOfHostiles = maxNumberOfHostiles}");
                }
            }
            else if (target.ToString() == "Aliens")
            {
                minNumberOfHostiles = 200000;
                maxNumberOfHostiles = 300000;

                if (target.Amount > maxNumberOfHostiles)
                {
                    Print($"[{ChosenClass}] Number of hostiles: {numberOfHostiles = rnd.Next(minNumberOfHostiles, maxNumberOfHostiles)}");
                }
                else if (target.Amount > minNumberOfHostiles)
                {
                    maxNumberOfHostiles = (int)target.Amount;

                    Print($"[{ChosenClass}] Number of hostiles: {numberOfHostiles = rnd.Next(minNumberOfHostiles, maxNumberOfHostiles)}");
                }
                else if (target.Amount < minNumberOfHostiles)
                {
                    maxNumberOfHostiles = (int)target.Amount;

                    Print($"[{ChosenClass}] Number of hostiles: {numberOfHostiles = maxNumberOfHostiles}");
                }
            }
            else if (target.ToString() == "Machines")
            {
                minNumberOfHostiles = 100000;
                maxNumberOfHostiles = 150000;

                if (target.Amount > maxNumberOfHostiles)
                {
                    Print($"[{ChosenClass}] Number of hostiles: {numberOfHostiles = rnd.Next(minNumberOfHostiles, maxNumberOfHostiles)}");
                }
                else if (target.Amount > minNumberOfHostiles)
                {
                    maxNumberOfHostiles = (int)target.Amount;

                    Print($"[{ChosenClass}] Number of hostiles: {numberOfHostiles = rnd.Next(minNumberOfHostiles, maxNumberOfHostiles)}");
                }
                else if (target.Amount < minNumberOfHostiles)
                {
                    maxNumberOfHostiles = (int)target.Amount;

                    Print($"[{ChosenClass}] Number of hostiles: {numberOfHostiles = maxNumberOfHostiles}");
                }
            }
            else
            {
                maxNumberOfHostiles = 1;

                Print($"[{ChosenClass}] Number of hostiles: {numberOfHostiles = maxNumberOfHostiles}");
            }

            PrintWithRepetition($"[{ChosenClass}] Calculating chances of survival");

            CalculateOdds(target);

            Print($"[{ChosenClass}] Chances of survival: ≈ {odds.ToString("0.##")} %");
        }

        public void Scan()
        {
            if (status == true)
            {
                PrintWithRepetition($"[{ChosenClass}] Scanning surroundings");

                GenerateScenario(TargetWorld.Targets[currentTarget]);

                Print($"[{ChosenClass}] Target engaged successfully: 50% chance Health + 5 and all are hostiles eliminated");
                Print($"[{ChosenClass}] Target engaged unsuccessfully: Health - 15 and not all hostiles are eliminated");
                Print($"[{ChosenClass}] Retreat: Live to fight another day and 50% chance Health - 5");
                Print($"[{ChosenClass}] Engage: Yes <Use the arrow keys to switch between 'Yes' and 'No'>");

                int choice = 1;
                bool correct = false;

                while (correct == false)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow:
                            Console.SetCursorPosition(ChosenClass.ToString().Length + 11, rows);
                            choice = (choice + 1) % 2;
                            if (choice == 0)
                            {
                                Print("No ");
                            }
                            else
                            {
                                Print("Yes");
                            }
                            rows--;
                            Console.SetCursorPosition(0, rows + 1);
                            break;
                        case ConsoleKey.RightArrow:
                            Console.SetCursorPosition(ChosenClass.ToString().Length + 11, rows);
                            choice = (choice + 1) % 2;
                            if (choice == 0)
                            {
                                Print("No ");
                            }
                            else
                            {
                                Print("Yes");
                            }
                            rows--;
                            Console.SetCursorPosition(0, rows + 1);
                            break;
                        case ConsoleKey.Enter:
                            correct = true;
                            break;
                        default:
                            Console.SetCursorPosition(0, rows + 1);
                            Console.Write(" ");
                            Console.SetCursorPosition(0, rows + 1);
                            break;
                    }
                }
                InitiateOutcome(choice);
            }
            else
            {
                Print("Robot is not active.");
            }
        }

        public void EvaluateSituation()
        {
            if (status == true)
            {
                Print($"[{ChosenClass}] Status: Active");
                PrintWithRepetition($"[{ChosenClass}] Assessing current situation");
                Print($"[{ChosenClass}] World: {TargetWorld}");
                Print($"[{ChosenClass}] Population: {TargetWorld.Population}");
                Print($"[{ChosenClass}] Health: {ChosenClass.Health}");

                if (TargetWorld.LifeForms)
                {
                    int notExistingTargets = 0;

                    Print($"[{ChosenClass}] Hostile life forms: ");

                    foreach (Target target in TargetWorld.Targets)
                    {
                        Print($"[{ChosenClass}] {target}: {target.Amount}");

                        if (target.Amount == 0)
                        {
                            notExistingTargets++;
                        }
                    }

                    if (notExistingTargets == TargetWorld.Targets.Count)
                    {
                        TargetWorld.LifeForms = false;

                        EvaluateSituation();
                    }
                }
                else
                {
                    int choice = 1;
                    bool correct = false;

                    if (TargetWorld.ToString() == "Moon")
                    {
                        harvestedWorlds[1] = "1";
                    }
                    else if (TargetWorld.ToString() == "Mars")
                    {
                        harvestedWorlds[2] = "1";
                    }
                    else
                    {
                        harvestedWorlds[3] = "1";
                    }

                    Print($"[{ChosenClass}] All hostiles have been harvested");
                    Print($"[{ChosenClass}] {TargetWorld}: Harvested");

                    if (harvestedWorlds[1] == "0" || harvestedWorlds[2] == "0" || harvestedWorlds[3] == "0")
                    {
                        Print($"[{ChosenClass}] Proceed to harvest the next world: Yes <Use the arrow keys to switch between 'Yes' and 'No'>");

                        while (correct == false)
                        {
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    Console.SetCursorPosition(ChosenClass.ToString().Length + 38, rows);
                                    choice = (choice + 1) % 2;
                                    if (choice == 0)
                                    {
                                        Print("No ");
                                    }
                                    else
                                    {
                                        Print("Yes");
                                    }
                                    rows--;
                                    Console.SetCursorPosition(0, rows + 1);
                                    break;
                                case ConsoleKey.RightArrow:
                                    Console.SetCursorPosition(ChosenClass.ToString().Length + 38, rows);
                                    choice = (choice + 1) % 2;
                                    if (choice == 0)
                                    {
                                        Print("No ");
                                    }
                                    else
                                    {
                                        Print("Yes");
                                    }
                                    rows--;
                                    Console.SetCursorPosition(0, rows + 1);
                                    break;
                                case ConsoleKey.Enter:
                                    correct = true;
                                    break;
                                default:
                                    Console.SetCursorPosition(0, rows + 1);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(0, rows + 1);
                                    break;
                            }
                        }

                        if (choice == 1)
                        {
                            currentTarget = 0;
                            travel = false;
                            status = false;
                            boot = false;

                            ShutDownRobot();
                            rows++;
                            GetTargetWorld();
                            Boot();
                            CalculateDistanceToTarget();
                            Travel();
                            Activate();
                            EvaluateSituation();
                        }
                        else
                        {
                            consoleShutDown = true;

                            ShutDownRobot();
                            Print("Mission: Success");
                            PrintWithRepetition("Console shutting down");
                            Print("FINISHED");
                        }
                    }
                    else
                    {
                        consoleShutDown = true;

                        Print($"[{ChosenClass}] All worlds have been harvested");
                        ShutDownRobot();
                        Print("Mission: Success");
                        PrintWithRepetition("Console shutting down");
                        Print("FINISHED");
                    }
                }
            }
            else
            {
                Print("Robot is deactivated.");
            }
        }

        private void ShutDownRobot()
        {
            PrintWithRepetition($"[{ChosenClass}] Systems shutting down");
            Print("AI: Offline");
            Print("Diagnostics: Offline");
            Print("Self repair kit: Offline");
            Print("Scanner: Offline");
            Print("Mobility: Offline");
            Print("Vision: Offline");
            Print("Sound perception: Offline");
            Print("Combat system: Offline");
            Print("Situation probability: Offline");
        }

        public void Activate()
        {
            if (status == false)
            {
                bool correct = false;

                while (correct == false)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            correct = true;
                            break;
                        default:
                            Console.SetCursorPosition(0, rows + 1);
                            Console.Write(" ");
                            Console.SetCursorPosition(0, rows + 1);
                            break;
                    }
                }

                Print("");
                PrintWithRepetition($"Activating {ChosenClass}");
                Print("");
                Print("AI: Online");
                Print("Diagnostics: Online");
                Print("Self repair kit: Online");
                Print("Scanner: Online");
                Print("Mobility: Online");
                Print("Vision: Online");
                Print("Sound perception: Online");
                Print("Combat system: Online");
                Print("Situation probability: Online");
                Print("");
                Print("All systems are online.");

                status = true;
            }
            else
            {
                Print("");
                Print($"{ChosenClass} is already active.");
            }
        }

        public void Travel()
        {
            if (travel == false)
            {
                int minTimeOfTravel = 5, maxTimeOfTravel = 15;
                int minShields = 76, maxShields = 100;

                #region landing
                Print("");
                PrintWithRepetition("Traveling");
                Print("");
                Print($"ETA: {rnd.Next(minTimeOfTravel, maxTimeOfTravel + 1)} minutes");
                Print($"Entering the atmosphere of {TargetWorld}.");
                Thread.Sleep(500);
                Print("");
                Print("!!! WARNING !!!");
                Print("");
                Print("Hostile life forms encountered. Unknown projectiles inbound.");
                Print("");
                Thread.Sleep(500);
                Print($"Shields at {rnd.Next(minShields, maxShields + 1)} % efficiency.");
                Thread.Sleep(500);
                minShields -= 25;
                maxShields -= 25;
                Print($"Shields at {rnd.Next(minShields, maxShields + 1)} % efficiency.");
                Thread.Sleep(500);
                minShields -= 25;
                maxShields -= 25;
                Print($"Shields at {rnd.Next(minShields, maxShields + 1)} % efficiency.");
                Thread.Sleep(500);
                minShields = 10;
                maxShields = 25;
                Print("");
                Print("!!! WARNING !!!");
                Print("");
                Print($"Shields at {rnd.Next(minShields, maxShields + 1)} % efficiency and rapidly decreasing.");
                Print("Shutting down all nonessential systems and redirecting the power towards the shields.");
                Thread.Sleep(500);
                minShields = 1;
                maxShields = 9;
                Print("");
                Print("!!! WARNING !!!");
                Print("");
                Print($"Shields at {rnd.Next(minShields, maxShields + 1)} % efficiency and rapidly decreasing.");
                Print("Temporarily shutting down systems until successful landing. ");
                Print("");
                PrintWithRepetition("Shutting down");
                Thread.Sleep(5000);
                #endregion

                #region before-activating
                Print("");
                PrintWithPause("Landing: ", "Success");
                PrintWithPause("Spaceship report: ", "Severely damaged");
                PrintWithPause($"{ChosenClass} report: ", "Intact");
                Print("");
                Print("Scanners suggest hostiles are aware of this unit's presence.");
                Print("Hostiles are converging towards this unit's location.");
                Print("Countermeasures of spaceship: Severely damaged");
                Print("Chances of survival in current situation: 0");
                Print("");
                PrintWithRepetition("Looking for possible solutions");
                Print($"Solution: Activate {ChosenClass}");
                PrintWithPause("Automatic activation: ", "Failed");
                Print("Solution: Manual activiation");
                Print("");
                Print($"<Hit the 'Enter' key in order to activate {ChosenClass}>");
                #endregion

                travel = true;
            }
            else
            {
                Print("");
                Print($"{ChosenClass} is already at the location of the targeted world.");
            }
        }

        public void CalculateDistanceToTarget()
        {
            if (travel == false)
            {
                int distanceToMoon = 52638263, distanceToMars = 159134924, distanceToEarth = 369420840;
                double timeToMoon = 71.52, timeToMars = 213.91, timeToEarth = 439.62;

                if (harvestedWorlds[1] == "1")
                {
                    if (harvestedWorlds[2] == "1")
                    {
                        timeToEarth += timeToMars + timeToMoon;
                        distanceToEarth += distanceToMars + distanceToMoon;
                    }
                    else if (harvestedWorlds[3] == "1")
                    {
                        timeToMars += timeToEarth + timeToMoon;
                        distanceToMars += distanceToEarth + distanceToMoon;
                    }
                    else
                    {
                        timeToEarth += timeToMoon;
                        timeToEarth += timeToMoon;
                        distanceToEarth += distanceToMoon;
                        distanceToMars += distanceToMoon;
                    }
                }
                else if (harvestedWorlds[2] == "1")
                {
                    if (harvestedWorlds[3] == "1")
                    {
                        timeToMoon += timeToMars + timeToEarth;
                        distanceToMoon += distanceToMars + distanceToEarth;
                    }
                    else
                    {
                        timeToEarth += timeToMars;
                        timeToMoon += timeToMars;
                        distanceToEarth += distanceToMars;
                        distanceToMoon += distanceToMars;
                    }
                }
                else if (harvestedWorlds[3] == "1")
                {
                    timeToMoon += timeToEarth;
                    timeToMars += timeToEarth;
                    distanceToMoon += distanceToEarth;
                    distanceToMars += distanceToEarth;
                }

                Print("");
                PrintWithRepetition($"Calculating distance to {TargetWorld} ");
                Print("Distance: " + (TargetWorld.ToString() == "Moon" ? $"≈ {distanceToMoon} km" :
                    (TargetWorld.ToString() == "Mars" ? $"≈ {distanceToMars} km" : $"≈ {distanceToEarth} km")));
                Print("");
                Print($"Setting a course for {TargetWorld}.");
                Print("ETA: " + (TargetWorld.ToString() == "Moon" ? $"≈ {timeToMoon} hours" :
                    (TargetWorld.ToString() == "Mars" ? $"≈ {timeToMars} hours" : $"≈ {timeToEarth} hours")));
                Print("");
                Print($"{ChosenClass} status: Inactive until arrival on {TargetWorld} ");
            }
            else
            {
                Print("");
                Print($"{ChosenClass} is already at the location of the targeted world");
            }
        }

        public void Boot()
        {
            if (boot == false)
            {
                Print("");
                Print($"Preparing {ChosenClass} for boot up.");
                Print("");
                Print("Checking for the existence of all physical components:");
                Print("");
                Print("Left leg: Exists");
                PrintWithLoading("Status:   0 % Ready");
                Print("Right leg: Exists");
                PrintWithLoading("Status:   0 % Ready");
                Print("Torso: Exists");
                PrintWithLoading("Status:   0 % Ready");
                Print("Left arm: Exists");
                PrintWithLoading("Status:   0 % Ready");
                Print("Right arm: Exists");
                PrintWithLoading("Status:   0 % Ready");
                Print("Head: Exists");
                PrintWithLoading("Status:   0 % Ready");
                Print("");
                Print("All physical components are in place and ready for use");
                Print("");
                Print($"Initialising {ChosenClass}.ai");
                Print("Initialising MovementAndBodyPartsCoordination.mabpc");
                Print("Initialising SelfRepairAndDiagnostics.srad");
                Print("Initialising CombatSystem.cs");
                Print("Initialising SituationProbability.sp");
                Print("Initialising TechTree.tt");
                Print("Initialising ObjectivesOfHarvest.ooh");
                Print("");
                Print("All systems have been initialised.");

                boot = true;
            }
            else
            {
                Print($"{ChosenClass} is already booted up.");
            }
        }

        private int WorldInput()
        {
            int choice = 0;
            string[] classes = { "", "Moon ", "Mars ", "Earth" };
            bool correct = false;

            #region worlds-stats
            Print("<Use the 'Left' / 'Right' arrow keys to switch between worlds >");
            Print("<Hit the 'Enter' key in order to confirm your chosen selection>");
            Print("");
            Print("World: Moon");

            if (harvestedWorlds[1] == "0")
            {
                Print("Life forms: True");
                Print($"Population: ≈ 1,000,000");
                Print("Defences: Weak");
                Print("Potential threats: Humans");
            }
            else
            {
                Print($"Life forms: {TargetWorld.LifeForms}");
                Print($"Population: ≈ {TargetWorld.Population}");
                Print("Defences: None");
                Print("Potential threats: None");

            }

            rows -= 5;
            Console.SetCursorPosition(29, rows);
            Print("World: Mars");

            if (harvestedWorlds[2] == "0")
            {
                Console.SetCursorPosition(29, rows);
                Print("Life forms: True");
                Console.SetCursorPosition(29, rows);
                Print("Population: ≈ 2,000,000");
                Console.SetCursorPosition(29, rows);
                Print("Defences: Decent");
                Console.SetCursorPosition(29, rows);
                Print("Potential threats: Humans");
                Console.SetCursorPosition(48, rows);
                Print("Aliens");
                Console.SetCursorPosition(48, rows);
                Print("Machines");
            }
            else
            {
                Console.SetCursorPosition(29, rows);
                Print($"Life forms: {TargetWorld.LifeForms}");
                Console.SetCursorPosition(29, rows);
                Print($"Population: ≈ {TargetWorld.Population}");
                Console.SetCursorPosition(29, rows);
                Print("Defences: None");
                Console.SetCursorPosition(29, rows);
                Print("Potential threats: None");
                Console.SetCursorPosition(48, rows);
                Print("");
                Console.SetCursorPosition(48, rows);
                Print("");
            }

            rows -= 7;

            Console.SetCursorPosition(60, rows);
            Print("World: Earth");

            if (harvestedWorlds[3] == "0")
            {
                Console.SetCursorPosition(60, rows);
                Print("Life forms: True");
                Console.SetCursorPosition(60, rows);
                Print("Population: ≈ 10,000,000");
                Console.SetCursorPosition(60, rows);
                Print("Defences: Strong");
                Console.SetCursorPosition(60, rows);
                Print("Potential threats: Humans");
                Console.SetCursorPosition(79, rows);
                Print("Aliens");
                Console.SetCursorPosition(79, rows);
                Print("Machines");
                Console.SetCursorPosition(79, rows);
                Print("Superheroes");
                Print("");
                Print("Choose the desired world to harvest: ");
                Print("");
            }
            else
            {
                Console.SetCursorPosition(60, rows);
                Print($"Life forms: {TargetWorld.LifeForms}");
                Console.SetCursorPosition(60, rows);
                Print($"Population: ≈ {TargetWorld.Population}");
                Console.SetCursorPosition(60, rows);
                Print("Defences: None");
                Console.SetCursorPosition(60, rows);
                Print("Potential threats: None");
                Console.SetCursorPosition(79, rows);
                Print("");
                Console.SetCursorPosition(79, rows);
                Print("");
                Console.SetCursorPosition(79, rows);
                Print("");
                Print("");
                Print("Choose the desired world to harvest: ");
                Print("");
            }
            #endregion

            while (correct == false)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        do
                        {
                            Console.SetCursorPosition(37, rows - 2);
                            choice = (choice + 1) % 3 + 1;
                            Print(classes[choice]);
                            rows--;
                            Console.SetCursorPosition(0, rows);
                        }
                        while (harvestedWorlds[choice] == "1");
                        break;
                    case ConsoleKey.RightArrow:
                        do
                        {
                            Console.SetCursorPosition(37, rows - 2);
                            choice = choice == 2 ? 3 : (choice + 1) % 3;
                            Print(classes[choice]);
                            rows--;
                            Console.SetCursorPosition(0, rows);
                        }
                        while (harvestedWorlds[choice] == "1");
                        break;
                    case ConsoleKey.Enter:
                        correct = true;
                        break;
                    default:
                        Console.SetCursorPosition(0, rows);
                        Console.Write(" ");
                        Console.SetCursorPosition(0, rows);
                        break;
                }
            }
            return choice;
        }

        public void GetTargetWorld()
        {
            if (status == false)
            {
                Print("");
                Print("Displaying information regarding the potential worlds for harvest: ");
                Print("");

                switch (WorldInput())
                {
                    case 1:
                        targetWorld = new World.Moon();
                        Print("World: Moon");
                        Print($"Life forms: {TargetWorld.LifeForms}");
                        Print($"Population: ≈ {TargetWorld.Population}");
                        Print("Defences: Weak");
                        Print("Potential threats: Humans");
                        rows--;
                        break;
                    case 2:
                        targetWorld = new World.Mars();
                        Print("World: Mars");
                        Print($"Life forms: {TargetWorld.LifeForms}");
                        Print($"Population: ≈ {TargetWorld.Population}");
                        Print("Defences: Decent");
                        Print("Potential threats: Humans");
                        Console.SetCursorPosition(19, rows);
                        Print("Aliens");
                        Console.SetCursorPosition(19, rows);
                        Print("Machines");
                        rows--;
                        break;
                    default:
                        targetWorld = new World.Earth();
                        Print("World: Earth");
                        Print($"Life forms: {TargetWorld.LifeForms}");
                        Print($"Population: ≈ {TargetWorld.Population}");
                        Print("Defences: Strong");
                        Print("Potential threats: Humans");
                        Console.SetCursorPosition(19, rows);
                        Print("Aliens");
                        Console.SetCursorPosition(19, rows);
                        Print("Machines");
                        Console.SetCursorPosition(19, rows);
                        Print("Superheroes");
                        rows--;
                        break;
                }
            }
            else
            {
                Print($"{ChosenClass} already chose a world to harvest");
            }
        }

        private int ClassInput()
        {
            int choice = 1;
            string[] classes = { "", "Bane     ", "Cleaner  ", "Daredevil" };
            bool correct = false;

            #region classes-stats
            Print("");
            Print("<Use the 'Left' / 'Right' arrow keys to switch between classes>");
            Print("<Hit the 'Enter' key in order to confirm your chosen selection>");
            Print("");
            Print("Class: Bane");
            Print("Health: 100");
            Print("Shield: 50");
            Print("Weapon: EyeLaser");
            Print("Damage: 1 - 60");
            rows -= 4;
            Console.SetCursorPosition(20, rows);
            Print("Class: Cleaner");
            Console.SetCursorPosition(20, rows);
            Print("Health: 75");
            Console.SetCursorPosition(20, rows);
            Print("Shield: 50");
            Console.SetCursorPosition(20, rows);
            Print("Weapon: SoulDrainer");
            Console.SetCursorPosition(20, rows);
            Print("Damage: 1 - 75");
            rows -= 5;
            Console.SetCursorPosition(43, rows);
            Print("Class: Daredevil");
            Console.SetCursorPosition(43, rows);
            Print("Health: 50");
            Console.SetCursorPosition(43, rows);
            Print("Shield: 50");
            Console.SetCursorPosition(43, rows);
            Print("Weapon: Katana");
            Console.SetCursorPosition(43, rows);
            Print("Damage: 1 - 100");
            Print("");
            Print("Choose the desired class: Bane");
            Print("");
            #endregion

            while (correct == false)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(26, rows - 2);
                        choice = (choice + 1) % 3 + 1;
                        Print(classes[choice]);
                        rows--;
                        Console.SetCursorPosition(0, rows);
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(26, rows - 2);
                        choice = choice == 2 ? 3 : (choice + 1) % 3;
                        Print(classes[choice]);
                        rows--;
                        Console.SetCursorPosition(0, rows);
                        break;
                    case ConsoleKey.Enter:
                        correct = true;
                        break;
                    default:
                        Console.SetCursorPosition(0, rows);
                        Console.Write(" ");
                        Console.SetCursorPosition(0, rows);
                        break;
                }
            }
            return choice;
        }

        private long CountPosibilities(int n, int k, int sum)
        {
            // if the desired sum is reached with `n` hits
            if (n == 0)
            {
                return (sum == 0) ? 1 : 0;
            }

            // the desired sum can't be reached with the current configuration
            if (sum < 0 || k * n < sum || n > sum)
            {
                return 0;
            }

            // if the subproblem is seen for the first time, solve it and
            // store its result in a 2D array or map
            if (lookup[n, sum] == 0)
            {
                // recur for all possible solutions
                for (int i = 1; i <= k; i++)
                {
                    lookup[n, sum] += CountPosibilities(n - 1, k, sum - i);
                }
            }

            return lookup[n, sum];
        }

        public Robot Initialise()
        {
            if (initialised == false)
            {
                Print("");
                Print("Initializing...");
                switch (ClassInput())
                {
                    case 1:
                        Print("Class: Bane");
                        Print("Health: 100");
                        Print("Shield: 50");
                        Print("Weapon: EyeLaser");
                        Print("Damage: 1 - 60");
                        chosenClass = new Bane();
                        return new Bane();
                    case 2:
                        Print("Class: Cleaner");
                        Print("Health: 75");
                        Print("Shield: 50");
                        Print("Weapon: SoulDrainer");
                        Print("Damage: 1 - 75");
                        chosenClass = new Cleaner();
                        return new Cleaner();
                    default:
                        Print("Class: Daredevil");
                        Print("Health: 50");
                        Print("Shield: 50");
                        Print("Weapon: Katana");
                        Print("Damage: 1 - 100");
                        chosenClass = new Daredevil();
                        return new Daredevil();
                }
            }
            else
            {
                Print("");
                Print($"{ChosenClass} has already been initialised.");
                return chosenClass;
            }
        }

        public static void StartMenu()
        {
            if (startMenu == false)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetWindowSize(100, 30);

                Print("");
                Print("+--------------------------------------------------------------------------------------------------+");
                Print("|                                                                                                  |");
                Print("|                                         WELCOME TO                                               |");
                Print("|                                          'HARVEST'                                               |");
                Print("|                                                                                                  |");
                Print("+--------------------------------------------------------------------------------------------------+");
                Print("");

                time = 30;

                Print("Loading all available classes: ");
                Print("");
                PrintWithPause("Bane: ", "Loaded.");
                PrintWithPause("Cleaner: ", "Loaded.");
                PrintWithPause("Daredevil: ", "Loaded.");
                Print("");
                Print("Acquiring information about the worlds that indicate life forms: ");
                Print("");
                PrintWithPause("Moon: ", "Acquired.");
                PrintWithPause("Mars: ", "Acquired.");
                PrintWithPause("Earth: ", "Acquired.");

                startMenu = true;
            }
            else
            {
                Print("Start Menu already initialised");
            }
        }

        private static void PrintWithRepetition(string message)
        {
            Print(message);

            time = 300;

            int contor = 0;

            while (contor < 10)
            {
                Console.SetCursorPosition(message.Length, rows);

                Print("...");

                rows--;

                Console.SetCursorPosition(message.Length, rows);

                time = 0;

                Print("   ");

                rows--;

                time = 300;

                contor++;
            }

            Console.SetCursorPosition(message.Length, rows);

            Print("...");

            rows--;

            time = 5;
        }

        private static void PrintWithLoading(string message)
        {
            Print(message);

            int contor = 0;

            time = 3;

            while (contor < 10)
            {
                Console.SetCursorPosition(message.Length - 9, rows);

                Print(contor.ToString());

                rows--;

                contor++;
            }

            while (contor < 100)
            {
                Console.SetCursorPosition(message.Length - 10, rows);

                Print(contor.ToString());

                rows--;

                contor++;
            }
            Console.SetCursorPosition(message.Length - 11, rows);

            Print(contor.ToString());

            rows--;

            time = 5;
        }

        private static void PrintWithPause(string message, string check)
        {
            Print(message);

            Console.SetCursorPosition(message.Length, rows);

            time = 1250;

            //Thread.Sleep(time);

            time = 5;

            Print(check);

            rows--;
        }

        private static void Print(string message)
        {
            rows++;

            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);

                //Thread.Sleep(time);
            }

            Console.Write("\n");
        }
    }
}