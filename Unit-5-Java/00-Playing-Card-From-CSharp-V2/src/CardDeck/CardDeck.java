//namespace Playing_Card_Poker_Game;
package CardDeck; // PackageName name must match teh folder name containing package components

// In C# you must code a using for any class you use that is in a different namespace
// In Java you must import any class you use that is in a different package
//     PackageName.Classname;
import PlayingCard.PlayingCard;  // Give me access to the PlayingCard class stuff

import java.util.ArrayList;      // Give me access to the ArrayList class stuff
import java.util.Collections;
import java.util.List;           // Give me access to the List class stuff
import java.util.Random;         // Give me access to the Random clas stuff

public class CardDeck
{
    /*************************************************************************************************
	 * CardDeck has a set of PLayingCards - "has-a" relationship - define the object in the class
	 ***************************************************************************************************/

	List<PlayingCard> deckOfCards = new ArrayList<PlayingCard>();  // Define a ArrayList to hold PlayingCards

	/***************************************************************************************************
	 * Number of non-Joker cards per suit
	 ***************************************************************************************************/
	private final int numberCardsForSuit = 13;  // final - cannot be changed (const/readonly in C#)

	/***************************************************************************************************
	 * Default Constructor
	 ***************************************************************************************************/

	public CardDeck()
	{
		resetDeck(true); // create deck with Jokers
	}

	/***************************************************************************************************
	 * Display cards in deck
	 ***************************************************************************************************/

	public void showDeck() {
		System.out.println("Number of Cards in Deck: " + deckOfCards.size());
		//   C#: foreach (PlayingCard aCard in deckOfCards)
		// Java: for(datatype variable : CollectionClassObject)
		for(PlayingCard aCard : deckOfCards) {
			aCard.showCardWithHash();
		}
	}
	/***************************************************************************************************
	 * Answer question are they any cards in the deck
	 ***************************************************************************************************/

	public boolean anyCardsInDeck() {
		if (deckOfCards.size() > 0)  // # elements in  the list - C#: .Count   Java: size()
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	/***************************************************************************************************
	 * Deal a card from the top of the deck
	 ***************************************************************************************************/
	public PlayingCard dealCard() {
		if (deckOfCards.size() > 0) // # elements in  the list - C#: .Count   Java: size()
		{
			// Simulate queue behavior (remove from head)
			PlayingCard cardToDeal = deckOfCards.get(0);  // get the 1st element - C#: [0]   Java:.get(0)
			deckOfCards.remove(0); // Remove 1st element - C# .Remove(0)   Java: .remove(0)
			return cardToDeal;
		}
		else
		{
			 return null;
		}
	}
	/***************************************************************************************************
	 * Empty card deck - throw in all the cards
	 ***************************************************************************************************/
	public void clearDeck() {
		deckOfCards.clear();
	}
	/***************************************************************************************************
	 * Add a card to the deck end of the deck
	 ***************************************************************************************************/
	public void addACardToEndofDeck(PlayingCard aCard) {
		deckOfCards.add(aCard);
	}

	/***************************************************************************************************
	 * Add a card to the deck top of the deck
	 ***************************************************************************************************/
	public void addACardToTopOfDeck(PlayingCard aCard) {
		deckOfCards.add(0, aCard);
	}

	/***************************************************************************************************
	 * Add a card to the Random place in the deck
	 ***************************************************************************************************/
	public int addACardToDeck(PlayingCard aCard) {
		Random randomNumberGenerator = new Random();

		int cardPosition = randomNumberGenerator.nextInt(deckOfCards.size());

		deckOfCards.add(cardPosition, aCard);

		return cardPosition;
	}

	/***************************************************************************************************
	 * Create a deck with or without Jokers
	 ***************************************************************************************************/
	public void resetDeck(boolean withJoker) {
		deckOfCards.clear();  // Remove any existing cards from the deck - C#: .Clear()   Java: .clear()

		// C#: .Add() to add to list     Java: .add()

		for (int i = 1; i <= numberCardsForSuit; i++) {    // Generate a set of clubs
			deckOfCards.add(new PlayingCard(i, PlayingCard.CardSuit.Club));
		}
		for (int i = 1; i <= numberCardsForSuit; i++) {    // Generate a set of hearts
			deckOfCards.add(new PlayingCard(i, PlayingCard.CardSuit.Heart));
		}
		for (int i = 1; i <= numberCardsForSuit; i++) {    // Generate a set of spades
			deckOfCards.add(new PlayingCard(i, PlayingCard.CardSuit.Spade));
		}
		for (int i = 1; i <= numberCardsForSuit; i++) {     // Generate a set of diamonds
			deckOfCards.add(new PlayingCard(i, PlayingCard.CardSuit.Diamond));
		}

		if (withJoker) {  // If Jokers requested, add them
			deckOfCards.add(new PlayingCard(PlayingCard.CardValue.Joker, PlayingCard.CardSuit.Joker));
			deckOfCards.add(new PlayingCard(PlayingCard.CardValue.Joker, PlayingCard.CardSuit.Joker));
		}
	}
	/***************************************************************************************************
	 * Create New Deck with Shuffled Cards - Long form
	 ***************************************************************************************************/
	public void shuffleNewDeck() {
		resetDeck(false);                  // Reload deck without Jokers

		// Use a standard Fisher-Yates shuffle algorithim 
		//
		// 1. Start with position of last item in a List or Array
		// 2. Loop thru the entire List or Array backwards
		// 3. Adjust current position to previous item in List or Array
		// 4. Generate a random position number
		// 5. Remember item in random position 
		// 6. Assign item in current position to random position
		// 7. Assign item in current postion the remember card from random position
		
		// Instantiate Random object to generate random card positions
		// 
		// To generate a Random value: .Next(largest-value-desired + 1)
		Random randomNumberGenerator = new Random();
		
		int currentCardPosition = deckOfCards.size();
		while (currentCardPosition > 1) {
			currentCardPosition--;
			// .get() - retrieve the element at the index
			int randomCardPosition = randomNumberGenerator.nextInt(currentCardPosition + 1);
			PlayingCard holdCard = deckOfCards.get(randomCardPosition);
			// set the element at an index
			// .set(index, object) - replace the object at the index with the object specified
			deckOfCards.set(randomCardPosition, deckOfCards.get(currentCardPosition));
			deckOfCards.set(currentCardPosition, holdCard);
		}
	}

	/***************************************************************************************************
	 * Shuffle existing Card Deck - Short form
	 ***************************************************************************************************/
	public void shuffleTheDeck() {
		Collections.shuffle(deckOfCards);
	}

	/***************************************************************************************************
	 * Remove any Jokers from a Deck
	 ***************************************************************************************************/
	public int removeJokers() {
		int numCardsBefore = deckOfCards.size();                       // Remember # cards before removal
		// Use RemoveAll with a predicate to remove cards matching the Joker criteria
		// This is the C# equivalent of C#'s removeAll(Collection) when the collection
		// contains the items to be removed.
		// .removeAll(Collection object) and it will remove all the objects that match the objects
		//                               in the Collection object you give
		//
 		// Define an ArrayList of objects we want removed from the deck
		// Create an ArrayList of Joker(s) - ArrayList is a Collection object
		List<PlayingCard> jokerCards = new ArrayList<PlayingCard>();
		// jokerCards.add(new PlayingCard());  // Create a default PlayingCard (a Joker)
		jokerCards.add(new PlayingCard(PlayingCard.CardValue.Joker, PlayingCard.CardSuit.Joker));

		// Remove the jokers and ignore teh boolean return by removeAll
		deckOfCards.removeAll(jokerCards); // C#: RemoveAll(card => card.Value == PlayingCard.CardValue.Joker && card.Suit == PlayingCard.CardSuit.Joker);

		return numCardsBefore - deckOfCards.size();                    // Return # of Jokers removed
	}
}