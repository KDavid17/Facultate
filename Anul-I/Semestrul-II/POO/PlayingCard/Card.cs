using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCard
{
    public class Card
    {
        private readonly string Rank;
        private readonly string Suit;

        private Card()
        {

        }

        public Card(string rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return Rank + " of " + Suit;
        }
    }
}
