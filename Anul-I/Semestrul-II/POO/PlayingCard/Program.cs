using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCard
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();

            myDeck.ShowCards();
            Console.WriteLine("#");
            myDeck.ShuffleCards();
            myDeck.ShowCards();
        }
    }
}
