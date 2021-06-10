using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCard
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();

        public Deck()
        {
            string rank;

            rank = "Ace";

            AddCards(rank);

            for (int i = 2; i <= 13; i++)
            {
                if (i > 10)
                {
                    switch (i)
                    {
                        case 11:
                            rank = "Jack";
                            break;
                        case 12:
                            rank = "Queen";
                            break;
                        case 13:
                            rank = "King";
                            break;
                        default:
                            throw new Exception("Invalid card rank!");
                    }
                }
                else
                {
                    rank = $"{i}"; 
                }
                
                AddCards(rank);
            }
        }
        
        private void AddCards(string rank)
        {
            cards.Add(new Card(rank, "Clubs"));
            cards.Add(new Card(rank, "Diamonds"));
            cards.Add(new Card(rank, "Hearts"));
            cards.Add(new Card(rank, "Spades"));
        }

        public void ShuffleCards()
        {
            List<Card> deckHelper = new List<Card>();

            Random rnd = new Random();

            int index;

            for (int i = 0; i < 52; i++)
            {
                index = rnd.Next(0, cards.Count());

                deckHelper.Add(cards[index]);

                cards.RemoveAt(index);
            }

            cards = deckHelper.ToList();
        }

        public void ShowCards()
        {
            foreach (Card item in cards)
            {
                Console.WriteLine(item);
            }
        }
    }
}
