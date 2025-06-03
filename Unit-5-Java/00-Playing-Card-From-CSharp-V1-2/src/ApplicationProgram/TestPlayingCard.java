package ApplicationProgram;  // Java is organized in packages
                             // C# is organized using namespaces
                             // Java PackageName should match the folder containing the
                             //      package components

import PlayingCard.PlayingCard;

public class TestPlayingCard {
    // C#:   Main() is spelled with uppercase "M"
    //       string may be spelled with lowercase or uppercase "S"
    //       (uppercase was added in .Net version 6)
    //       Console.WriteLine() to display a line to the screen

    // Java: main() is spelled with a lowercase "m"
    //       String is always spelled with uppercase "S"
    //       (because it is a Class - has data methods)
    //       System.out.println() to display a line to the screen

    // this is exactly how C# defines Main() but lowercase "m"



    public static void main(String[] args) {

        System.out.println("Hello, World!");

        // Define an Ace of Spades
        // Syntax is just like C#
    //  ClassName   objectName  = new ClassName();  // Calling a constructor for the class
        PlayingCard aceOfSpades = new PlayingCard(PlayingCard.CardValue.Ace, PlayingCard.CardSuit.Spade);

        // Display the PlayingCard
        System.out.println(aceOfSpades);

        // Call the method to flip the card over
        // object.method()
        aceOfSpades.flip();

        // Display the PlayingCard
        System.out.println(aceOfSpades);

    } // End of main() method
} // End of TestPlayingCard CLass