namespace Playing_Card_Poker_Game;

public class TestPokerHands
{
    private PokerHand   aPokerHand = new PokerHand();
    
    private PlayingCard aceDiamonds = new PlayingCard(PlayingCard.CardValue.Ace, PlayingCard.CardSuit.Diamond);
    private PlayingCard aceHearts   = new PlayingCard(PlayingCard.CardValue.Ace, PlayingCard.CardSuit.Heart);
    private PlayingCard aceSpades   = new PlayingCard(PlayingCard.CardValue.Ace, PlayingCard.CardSuit.Spade);
    private PlayingCard aceClubs    = new PlayingCard(PlayingCard.CardValue.Ace, PlayingCard.CardSuit.Club);

    private PlayingCard kingDiamonds = new PlayingCard(PlayingCard.CardValue.King, PlayingCard.CardSuit.Diamond);
    private PlayingCard kingHearts   = new PlayingCard(PlayingCard.CardValue.King, PlayingCard.CardSuit.Heart);
    private PlayingCard kingSpades   = new PlayingCard(PlayingCard.CardValue.King, PlayingCard.CardSuit.Spade);
    private PlayingCard kingClubs    = new PlayingCard(PlayingCard.CardValue.King, PlayingCard.CardSuit.Club);

    private PlayingCard queenDiamonds = new PlayingCard(PlayingCard.CardValue.Queen, PlayingCard.CardSuit.Diamond);
    private PlayingCard queenHearts   = new PlayingCard(PlayingCard.CardValue.Queen, PlayingCard.CardSuit.Heart);
    private PlayingCard queenSpades   = new PlayingCard(PlayingCard.CardValue.Queen, PlayingCard.CardSuit.Spade);
    private PlayingCard queenClubs    = new PlayingCard(PlayingCard.CardValue.Queen, PlayingCard.CardSuit.Club);

    private PlayingCard jackDiamonds  = new PlayingCard(PlayingCard.CardValue.Jack, PlayingCard.CardSuit.Diamond);
    private PlayingCard jackHearts    = new PlayingCard(PlayingCard.CardValue.Jack, PlayingCard.CardSuit.Heart);
    private PlayingCard jackSpades    = new PlayingCard(PlayingCard.CardValue.Jack, PlayingCard.CardSuit.Spade);
    private PlayingCard jackClubs     = new PlayingCard(PlayingCard.CardValue.Jack, PlayingCard.CardSuit.Club);

    private PlayingCard tenDiamonds   = new PlayingCard(PlayingCard.CardValue.Ten, PlayingCard.CardSuit.Diamond);
    private PlayingCard tenHearts     = new PlayingCard(PlayingCard.CardValue.Ten, PlayingCard.CardSuit.Heart);
    private PlayingCard tenSpades     = new PlayingCard(PlayingCard.CardValue.Ten, PlayingCard.CardSuit.Spade);
    private PlayingCard tenClubs      = new PlayingCard(PlayingCard.CardValue.Ten, PlayingCard.CardSuit.Club);
   
    private PlayingCard nineDiamonds  = new PlayingCard(PlayingCard.CardValue.Nine, PlayingCard.CardSuit.Diamond);
    private PlayingCard nineHearts    = new PlayingCard(PlayingCard.CardValue.Nine, PlayingCard.CardSuit.Heart);
    private PlayingCard nineSpades    = new PlayingCard(PlayingCard.CardValue.Nine, PlayingCard.CardSuit.Spade);
    private PlayingCard nineClubs     = new PlayingCard(PlayingCard.CardValue.Nine, PlayingCard.CardSuit.Club);


    private PlayingCard twoDiamonds   = new PlayingCard(PlayingCard.CardValue.Two, PlayingCard.CardSuit.Diamond);
    private PlayingCard threeHearts   = new PlayingCard(PlayingCard.CardValue.Three, PlayingCard.CardSuit.Heart);
    private PlayingCard fourSpades    = new PlayingCard(PlayingCard.CardValue.Four, PlayingCard.CardSuit.Spade);
    private PlayingCard fiveClubs     = new PlayingCard(PlayingCard.CardValue.Five, PlayingCard.CardSuit.Club);
    
    public void run()
    {
        HighCardWithAceTest(); 
        HighCardWithoutAceTest();
        OnePairTest();
        TwoPairTest();
        ThreeOfAKindTest();
        FullHouseTest();
        FourOfAKindTest();
        StraightTest();
        StraightAceLowTest();
        StraightAceHiTest();
        FlushTest();
        StraightFlushTest();
        RoyalStraightFlushTest();
    }
    
    void HighCardWithAceTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(kingClubs);
        aPokerHand.AddCard(twoDiamonds);
        aPokerHand.AddCard(queenDiamonds);
        aPokerHand.AddCard(jackClubs);
        Console.WriteLine($"Testing for High Card With Ace: {aPokerHand.RankHand()}");
    }
    void HighCardWithoutAceTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(twoDiamonds);
        aPokerHand.AddCard(kingClubs);
        aPokerHand.AddCard(tenClubs);
        aPokerHand.AddCard(queenDiamonds);
        aPokerHand.AddCard(jackClubs);
        Console.WriteLine($"Testing for High Without Ace Card: {aPokerHand.RankHand()}");
    }
    void OnePairTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(kingClubs);
        aPokerHand.AddCard(kingClubs);
        aPokerHand.AddCard(twoDiamonds);
        aPokerHand.AddCard(jackClubs);
        Console.WriteLine($"Testing for Pair: {aPokerHand.RankHand()}");
    }
    void TwoPairTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(jackClubs);
        aPokerHand.AddCard(twoDiamonds);
        aPokerHand.AddCard(jackClubs);
        Console.WriteLine($"Testing for Two Pair: {aPokerHand.RankHand()}");
    }
    void ThreeOfAKindTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(aceSpades);
        aPokerHand.AddCard(aceDiamonds);
        aPokerHand.AddCard(twoDiamonds);
        aPokerHand.AddCard(jackClubs);
        Console.WriteLine($"Testing for Three of a Kind: {aPokerHand.RankHand()}");
    }
    void FourOfAKindTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(aceSpades);
        aPokerHand.AddCard(aceDiamonds);
        aPokerHand.AddCard(aceHearts);
        aPokerHand.AddCard(jackClubs);
        Console.WriteLine($"Testing for Four of a Kind: {aPokerHand.RankHand()}");
    }

    void FullHouseTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(aceSpades);
        aPokerHand.AddCard(aceDiamonds);
        aPokerHand.AddCard(jackDiamonds);
        aPokerHand.AddCard(jackClubs);
        Console.WriteLine($"Testing for Full House: {aPokerHand.RankHand()}");
    }
    void StraightTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(nineClubs);
        aPokerHand.AddCard(kingClubs);
        aPokerHand.AddCard(queenDiamonds);
        aPokerHand.AddCard(jackHearts);
        aPokerHand.AddCard(tenDiamonds);        
        Console.WriteLine($"Testing for Straight: {aPokerHand.RankHand()}");
    }
    void StraightAceLowTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(twoDiamonds);
        aPokerHand.AddCard(threeHearts);
        aPokerHand.AddCard(fourSpades);
        aPokerHand.AddCard(fiveClubs);
        Console.WriteLine($"Testing for Ace Low Straight: {aPokerHand.RankHand()}");
    }
    void StraightAceHiTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(kingClubs);
        aPokerHand.AddCard(queenDiamonds);
        aPokerHand.AddCard(jackHearts);
        aPokerHand.AddCard(tenDiamonds);
        Console.WriteLine($"Testing for Ace High Straight: {aPokerHand.RankHand()}");
    }
    void FlushTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(kingClubs);
        aPokerHand.AddCard(nineClubs);
        aPokerHand.AddCard(tenClubs);
        aPokerHand.AddCard(fiveClubs);
        Console.WriteLine($"Testing for Flush: {aPokerHand.RankHand()}");
    }

    void StraightFlushTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(kingClubs);
        aPokerHand.AddCard(queenClubs);
        aPokerHand.AddCard(jackClubs);
        aPokerHand.AddCard(tenClubs);
        aPokerHand.AddCard(nineClubs);
        Console.WriteLine($"Testing for Straight Flush: {aPokerHand.RankHand()}");
    }
    
    void RoyalStraightFlushTest()
    {
        aPokerHand.ClearHand();
        aPokerHand.AddCard(aceClubs);
        aPokerHand.AddCard(kingClubs);
        aPokerHand.AddCard(queenClubs);
        aPokerHand.AddCard(jackClubs);
        aPokerHand.AddCard(tenClubs);
        Console.WriteLine($"Testing for Royal Straight Flush: {aPokerHand.RankHand()}");
    }
}
