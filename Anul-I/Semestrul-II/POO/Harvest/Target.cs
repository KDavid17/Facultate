namespace Harvest
{
    public class Target
    {
        private double hitpoints, damage;
        private int amount;

        public double Hitpoints { get { return hitpoints; } }
        public double Damage { get { return damage; } }
        public int Amount { get { return amount; } set { amount = value; } }

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
