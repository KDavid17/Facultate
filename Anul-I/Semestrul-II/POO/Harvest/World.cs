using System.Collections.Generic;

namespace Harvest
{
    public class World
    {
        private bool lifeForms = true;
        private int population;
        private List<Target> targets = new List<Target>();
        
        public bool LifeForms { get { return lifeForms; } set { lifeForms = value; } }
        public int Population { get { return population; } set { population = value; } }
        public List<Target> Targets { get { return targets; } }

        public class Moon : World
        {
            public Moon()
            {
                population = 1000000;
                targets.Add(new Target.Humans());
                targets[0].Amount = population;
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
                targets[0].Amount = 1272325;  
                targets.Add(new Target.Aliens());
                targets[1].Amount = 727675;             
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
                targets[0].Amount = 6134597;    
                targets.Add(new Target.Aliens());
                targets[1].Amount = 2865675;    
                targets.Add(new Target.Machines());
                targets[2].Amount = 999728;
            }

            public override string ToString()
            {
                return "Earth";
            }
        }
    }
}
