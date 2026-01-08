namespace Playing_Card_Poker_Game;

public class PokerGame
{
    public void run()
    {
        List<PokerHand> hands = new List<PokerHand>();
        int numGames = 10;
        int numHands = 5;
        bool showHand = false;

        for (int i = 0; i < numGames; i++) // Play some Hands
        {
            CardDeck aDeck = new CardDeck(); // Start with ne deck

            aDeck.ShuffleDeck(); // Shuffle the deck
            hands.Clear(); // CLear all hands
            for (int j = 0; j < numHands; j++) // Deal hands
            {
                PokerHand aHand = new PokerHand(); // Instantiate new hand
                aHand.DealHand(aDeck); // Deal cards to hand
                aHand.RankHand(); // Rank the hand
                hands.Add(aHand); // Add hand to game
                
            } // End of one iteration of dealing hands
            
            PokerHand winner = new PokerHand();  // Hold winning hand - default ranking is NotRanked
            
            for (int k = 0; k < numHands; k++) // Loop though hand
            {
                Console.WriteLine($"----- Game {i+1} - Hand {k + 1} - Hand Rank: {hands[k].HandRank}");
                if (showHand)
                {
                    hands[k].Show(); // Display hand
                }

                // Console.WriteLine($" Hand{k + 1} rank {hands[k].HandRank}"); // Display rank of a hand
                
                if (hands[k].HandRank > winner.HandRank) // If highest hand...
                {
                    winner = hands[k]; //     save it
                }
            } // End of hand evaluation loop
            Console.WriteLine($"Game {i} Winning Hand: {winner.HandRank}\n"); // Display winning hand rank
        } // End play some games loop
        Console.WriteLine("\n-------------- End of This Episode of Poker Game -----------------");
    } // End run() method
} // End PokerGame class