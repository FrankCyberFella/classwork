namespace PlayingCardProject;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Instantiate an Ace of Spades
        PlayingCard aCard = new PlayingCard("Spades", "Black", 1);
        
        // Display our card
        Console.WriteLine(aCard);
    }
}