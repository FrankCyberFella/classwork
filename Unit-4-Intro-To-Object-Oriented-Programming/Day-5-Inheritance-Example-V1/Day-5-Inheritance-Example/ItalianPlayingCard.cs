namespace Day_5_Inheritance_Example;

// This is subclass of a PlayingCard

public class ItalianPlayingCard : PlayingCard
{
    // Define a default ctor that calls the base class ctor
    public ItalianPlayingCard() : base(0, "Joker", "Black") {}

    // Define a 2-arg ctor for value and suit
    public ItalianPlayingCard(int theValue, string theSuit, string theColor)
      : base(theValue, theSuit, theColor){}
}