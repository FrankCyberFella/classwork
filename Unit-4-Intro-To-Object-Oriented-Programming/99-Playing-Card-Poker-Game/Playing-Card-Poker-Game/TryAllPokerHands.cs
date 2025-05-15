using System;
namespace Playing_Card_Poker_Game;

public class TryAllPokerHands
{
	public void run()
	{
		CardDeck myDeck = new CardDeck();
//		CardHand myHand = new CardHand();   // cannot instantiate CardHand - it's abstract
		PokerHand myPokerHand = new PokerHand();

		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine("-- Showing Cards in Deck                           --");
		Console.WriteLine("-----------------------------------------------------");

		myDeck.ShowDeck();

		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine("-- Removing Jokers from Deck                       --");
		Console.WriteLine("-----------------------------------------------------");

		Console.WriteLine("Number Jokers Removed: " + myDeck.RemoveJokers());

		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine("-- Shuffling Deck                                  --");
		Console.WriteLine("-----------------------------------------------------");

		myDeck.ShuffleDeck();

		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine("-- Dealing Cards from Deck                         --");
		Console.WriteLine("-----------------------------------------------------");

		while (myDeck.AnyCardsInDeck())
			Console.WriteLine(myDeck.DealCard().ToString());

		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine("-- Dealing Cards to a PokerHand                    --");
		Console.WriteLine("-----------------------------------------------------");

		myDeck.ResetDeck(false);
		myDeck.ShuffleDeck();

		myPokerHand.DealHand(myDeck);

		myPokerHand.Show();

		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine("-- Sorting PokerHand by Value                      --");
		Console.WriteLine("-----------------------------------------------------");

		myPokerHand.SortByValue();
		myPokerHand.Show();

		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine("-- Sorting PokerHand by Color                      --");
		Console.WriteLine("-----------------------------------------------------");

		myPokerHand.SortByColor();
		myPokerHand.Show();

		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine("-- Sorting PokerHand by Suit                       --");
		Console.WriteLine("-----------------------------------------------------");

		myPokerHand.SortBySuit();
		myPokerHand.Show();

		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine("-- Test Hand Ranking                               --");
		Console.WriteLine("-----------------------------------------------------");

		Console.WriteLine(string.Format("Hands found: {0}\n", findHand(100, PokerHand.PokerHandRanking.Pair, false)));
		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine(string.Format("Hands found: {0}\n",
			findHand(100, PokerHand.PokerHandRanking.Two_Pair, false)));
		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine(string.Format("Hands found: {0}\n", findHand(1000, PokerHand.PokerHandRanking.Flush, false)));
		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine(string.Format("Hands found: {0}\n",
			findHand(1000, PokerHand.PokerHandRanking.Straight, false)));
		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine(string.Format("Hands found: {0}\n",
			findHand(1000, PokerHand.PokerHandRanking.Full_House, true)));
		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine(string.Format("Hands found: {0}\n",
			findHand(20000, PokerHand.PokerHandRanking.Four_Of_A_Kind, true)));
		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine(string.Format("Hands found: {0}\n",
			findHand(100000, PokerHand.PokerHandRanking.Straight_Flush, true)));
		Console.WriteLine("-----------------------------------------------------");
		Console.WriteLine(string.Format("Hands found: {0}\n",
			findHand(1000000, PokerHand.PokerHandRanking.Royal_Straight_Flush, true)));
		Console.WriteLine("-----------------------------------------------------");
	}

//**********************************************************************************
//  Determine if a particular poker hand is dealt in a specified number of hands
//**********************************************************************************
	/**
	 * @param numTries   - Number of hands to deal
	 * @param whatRank   - PokerHandRaking to look for
	 * @param showResult - true / false
	 * @return
	 */
	public static int findHand(int numTries, PokerHand.PokerHandRanking whatRank, bool showResult)
	{
		int numFound = 0;

		CardDeck aDeck = new CardDeck();
		PokerHand aPokerHand = new PokerHand();

		Console.WriteLine($"Looking for {whatRank} in {numTries} hands...");

		for (int i = 0; i < numTries; i++)
		{

			aPokerHand.ClearHand();
			aDeck.ResetDeck(false);
			aDeck.ShuffleDeck();

			aPokerHand.DealHand(aDeck);

			if (aPokerHand.RankHand() == whatRank)
			{
				if (showResult)
				{
					Console.WriteLine("\n" + aPokerHand.RankHand() + "\n");
					aPokerHand.Show();
				}

				numFound++;
			}
		}

		return numFound;
	}
}