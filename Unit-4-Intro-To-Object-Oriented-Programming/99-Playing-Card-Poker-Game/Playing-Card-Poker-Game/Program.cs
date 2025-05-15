namespace Playing_Card_Poker_Game;

public class Program
{
	// Application program - instantiate class and manipulate them to get work done
    // Main() tells us its an application program

    public static void Main(string[] args)
    {
	    // Run TestPokerHands Test Class
	    TestPokerHands aPokerHandsTest = new TestPokerHands();
	    //aPokerHandsTest.run();   // Verify hand is ranked correctly ass a Poker hand
	    
	    // Run TryAllPokerHand Test Class
	    TryAllPokerHands aPokerHandsTryAll = new TryAllPokerHands();  // Run multiple hands through verification
	    //aPokerHandsTryAll.run();
	    
	    // Run a Poker Game
	    PokerGame aGame = new PokerGame();
	    //aGame.run();   // Start of a Poker Game simulation


    }
}
