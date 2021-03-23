using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot.StartMenu();
            Robot robot = new Robot().Initialise();
            robot.GetTargetWorld();
            robot.Boot();
            robot.CalculateDistanceToTarget();
            robot.Travel();
            robot.Activate();
            robot.EvaluateSituation();

            while (robot.ConsoleShutDown == false)
            {
                robot.Scan();
                robot.EvaluateSituation();
            }        
        }
    }
}
