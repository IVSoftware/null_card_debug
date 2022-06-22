using System;
using System.Collections.Generic;

namespace null_card_debug
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            var testCaseCards = new Card[]
            {
                new Card{Rank = Rank.Ace, Suit = Suit.Spades},
                new Card{Rank = Rank.Ace, Suit = Suit.Hearts},
                new Card{Rank = Rank.Eight, Suit = Suit.Spades},
                new Card{Rank = Rank.Eight, Suit = Suit.Hearts},
                new Card{Rank = Rank.Eight, Suit = Suit.Diamond},
            };

            cards.AddRange(testCaseCards);

            Console.WriteLine(cards.Count);
            List<List<Card>> cardsSuits = new List<List<Card>>();
            List<Card> tempList = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                Console.Write(suit.ToString());
                tempList = cards.FindAll(card => isSuit(card, suit));
                cardsSuits.Add(tempList);
                Console.WriteLine($" has {tempList.Count} cards.");
            }
        }

        private static bool isSuit(Card card, Suit suit)
        {
            // Set a break point here. When the null card comes in
            // (as it surely will) you can answer 'why' for yourself.
            if (card == null)
            {
                // This is bad, mkay?
                System.Diagnostics.Debug.Assert(false, "Expecting a non-null card");
                return false; // But at least it won't crash now.
            }
            else
            {
                return card.Suit == suit;
            }
        }
    }
    enum Suit
    {
        Clubs,
        Diamond,
        Hearts,
        Spades,
    }
    enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }

    internal class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
    }
}
