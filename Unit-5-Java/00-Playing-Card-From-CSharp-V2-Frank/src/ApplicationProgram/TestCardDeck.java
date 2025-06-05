package ApplicationProgram;

import CardDeck.CardDeck;
import PlayingCard.PlayingCard;

import java.util.*;

public class TestCardDeck {
//
    public static void main(String[] args) {

        System.out.println("Welcome to my Second Java program!");

        // Instantiate a CardDeck
        CardDeck aCardDeck = new CardDeck();

        // Display all the cards in the deck
        aCardDeck.showDeck();

        System.out.println("\n--- Removing Jokers ---");

        aCardDeck.removeJokers();
        aCardDeck.showDeck();

        aCardDeck.shuffleTheDeck();

        PlayingCard aCard = aCardDeck.dealCard();  // remove card and return
        aCard.showCard();

        /*****************************************************************************************
         * dealCard() removes a card from the cardDeck and returns it
         *
         * if one would like to create a discard pile of dealt cards a decision needs to be made:
         *
         *   1. Do you want the discard pile to have the same behaviors as a CardDeck?
         *   2. Do you want the discard pile to just be a simple pile of cards?
         *****************************************************************************************/

        /*****************************************************************************************
         * Discard pile is to have same behaviors as a CardDeck (use CardDeck methods)
         ****************************************************************************************/
        System.out.println("\n--- Discard Pile as CardDeck ---");

        CardDeck discardCardDeck = new CardDeck();  // Instantiate discard pile as new deck of cards
        discardCardDeck.clearDeck();                // Remove all cards form the deck

        discardCardDeck.addACardToTopOfDeck(aCardDeck.dealCard());  // "bury" top card from the deck
        discardCardDeck.addACardToTopOfDeck(aCard);                 // add an existing card to discard pile
        discardCardDeck.showDeck();                                 // Display dicard pile
        discardCardDeck.shuffleTheDeck();                           // Shuffle the discard pile
        discardCardDeck.addACardToEndofDeck(aCardDeck.dealCard());  // Add a card to bottom of discard file
        discardCardDeck.addACardToDeck(aCardDeck.dealCard());       // Insert card in discard pile
        discardCardDeck.showDeck();                                 // Display cards in discard pile

        /*****************************************************************************************
         * Discard pile to be a simple pile of cards (Cannot use CardDeck methods)
         ****************************************************************************************/
        System.out.println("\n--- Discard Pile as Simple Pile of Cards ---");
        List<PlayingCard> discardPile = new ArrayList<>();// Instantiate Discard pile
        discardPile.addFirst(aCardDeck.dealCard());       // "bury" top card from the deck
        discardPile.add(aCard);                           // add an existing card to discard pile

        for (PlayingCard discardPileCard : discardPile) { // Display discard pile
            System.out.println(discardPileCard);
        }
        Collections.shuffle(discardPile);                // Shuffle the discard pile
        discardPile.addLast(aCardDeck.dealCard());       // Add a card to bottom of discard pile

        // Insert card in discard pile
        Random randomNumberGenerator = new Random();
        discardPile.add(randomNumberGenerator.nextInt(discardPile.size()), aCardDeck.dealCard());

        // Display cards in discard pile
        for(PlayingCard discardPileCard : discardPile) {
            System.out.println(discardPileCard);
        }
/******************************************************************************
 * Demonstrate use of the Java Set class
 *
 * A Set is an ArrayList that will not allow duplicates
 *
 * Since a Set is an implemention of Collections interface, like List
 *         the same methods that work with List work with Set
 *
 ******************************************************************************/

    System.out.println("\n--- Demo of ArrayList vs Set ---");

    // Define an ArrayList
    List<String> names = new ArrayList<>();

    names.add("Frank");
    names.add("Aaron");
    names.add("Jay");
    names.add("frank");

    System.out.println("\n--- Here's the ArrayList ---");
    // display the list of name
    for(String aName : names){
        System.out.println(aName);
    }
    // Add a duplicate name
    names.add("Frank");

    System.out.println("\n--- Here's the ArrayList after adding duplicate name---");
    System.out.println("\n--- The duplicate name WAS stored                   ---");
    // display the list of name
    for(String aName : names){
        System.out.println(aName);
    }

    // Define a Set class object as a HashSet
    //    HashSet - stores the entries in an unknown sequence (by hashCode)
    //              hashCode is a unique representing the data in the object
    //              hashCode is generated by the hashCode() method for the class
    //
    //    TreeSet - stores the entries in a sort sequence (based on the type)
    //
    //    LinkedHashSet - stores the entries in entry sequence (just like ArrayList)

    Set<String> nameSet = new LinkedHashSet<>();  // Store element in entry sequence
//  Set<String> nameSet = new HashSet<>();        // Store element in hashCode (unknown to you)
//  Set<String> nameSet = new TreeSet<>();        // Store element in sort sequence based on type

    nameSet.add("frank");
    nameSet.add("Frank");
    nameSet.add("Jay");
    nameSet.add("Aaron");


    System.out.println("\n--- Here's the Set ---");
    // display the list of name
    for(String aName : nameSet){
        System.out.println(aName);
    }
    // Add a duplicate name
    nameSet.add("Frank");

    System.out.println("\n--- Here's the Set after adding duplicate name---");
    System.out.println("\n--- The duplicate name was NOT stored         ---");
    // display the list of name
    for(String aName : nameSet){
        System.out.println(aName);
    }

    } // End of main() method
} // End of TestPlayingCard CLass