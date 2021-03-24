using System.Collections.Generic;

namespace Harvest
{
    public class World
    {
        private bool lifeForms = true;
        private double hitpoints, damage;
        private long population, amount;
        private List<Target> targets = new List<Target>();
        
        public bool LifeForms { get { return lifeForms; } set { lifeForms = value; } }
        public long Population { get { return population; } set { population = value; } }
        public long Amount { get { return amount; } set { amount = value; } }
        public double Hitpoints { get { return hitpoints; } }
        public double Damage { get { return damage; } }
        public List<Target> Targets { get { return targets; } }

        public class Moon : World
        {
            public Moon()
            {
                population = 1000000;
                targets.Add(new Target.Humans());
                targets[0].amount = population;
            }

            public override string ToString()
            {
                return "Moon";
            }
        }

        public class Mars : World
        {
            public Mars()
            {
                population = 2000000;
                
                targets.Add(new Target.Humans());
                targets[0].amount = 1272325;  
                targets.Add(new Target.Aliens());
                targets[1].amount = 727675;             
            }

            public override string ToString()
            {
                return "Mars";
            }
        }

        public class Earth : World
        {
            public Earth()
            {
                population = 10000000;

                targets.Add(new Target.Humans());
                targets[0].amount = 6134597;    
                targets.Add(new Target.Aliens());
                targets[1].amount = 2865675;    
                targets.Add(new Target.Machines());
                targets[2].amount = 999728;
            }

            public override string ToString()
            {
                return "Earth";
            }
        }

        public class Target : World
        {
            public class Humans : Target
            {
                public Humans()
                {
                    hitpoints = 0.00025;
                    damage = 0.0001;
                }

                public override string ToString()
                {
                    return "Humans";
                }
            }

            public class Aliens : Target
            {
                public Aliens()
                {
                    hitpoints = 0.0005;
                    damage = 0.0002;
                }

                public override string ToString()
                {
                    return "Aliens";
                }
            }

            public class Machines : Target
            {
                public Machines()
                {
                    hitpoints = 0.001;
                    damage = 0.0004;
                }

                public override string ToString()
                {
                    return "Machines";
                }
            }
        }
    }
}
