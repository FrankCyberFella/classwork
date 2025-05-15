using System;
using System.Collections.Generic;

namespace Playing_Card_Poker_Game;
/***************************************************************************************************
 * Class to Simulate an American Playing Card Hand
 *
 * abstract means it's meant be a super class and cannot be instantiated on it's own
 *
 * An abstract class provides a generic description of an object
 *
 * CardHand is a type of IValidCardHand - "type of" - implement an interface
 ***************************************************************************************************/
public abstract class CardHand   : IValidCardHand  { // a CardHand is type of IValidCardHand

	/***********************************************************************************************
	 * Member Data
	 ***********************************************************************************************/

	private int numCardsInHand;         // Maximum number of cards in hand
	protected List<PlayingCard> aHand;  // Reference to the PlayingCard Hand

	/***********************************************************************************************
	 * Properties
	 ***********************************************************************************************/
	 public int NumCardsInHand { get; protected set; } 
	
	/***********************************************************************************************
	 * Constructors
	 ***********************************************************************************************/

	public CardHand() {            // Default constructor
		NumCardsInHand = 5;        // Default number of cards in a hand
		aHand = new List<PlayingCard>(numCardsInHand);  // Allocate enough slots for number cards in hand
	}
	
	public CardHand(int numCards) { // Constructor to create a specific number of cards in Hand
		numCardsInHand = numCards;  // Set number of cards in Hand to value passed
		aHand = new List<PlayingCard>(numCardsInHand);  // Allocate enough slots for number cards in hand
	}

	/***********************************************************************************************
	 * getters
	 ***********************************************************************************************/
	public List<PlayingCard> GetHand() {
		return aHand;
	}

/***************************************************************************************************
 * Overrides of superclass or interface methods
 ***************************************************************************************************/
// Ask compiler to check to be sure this is a valid override of superclass or interface method
	public void AddCard(PlayingCard aCard) {
		aHand.Add(aCard);

}
// Ask compiler to check to be sure this is a valid override of superclass or interface method
	public void ClearHand() {   // Remove all cards from Hand
		aHand.Clear();
	}

// Ask compiler to check to be sure this is a valid override of superclass or interface method
	public abstract void DealHand(CardDeck aDeck);  // Required by interface, but this class doesn't know
	                                                //        what it does
	                                                // abstract means the sub class must define it

// Ask compiler to check to be sure this is a valid override of superclass or interface method
	public virtual void Show() {                // Display each card in Hand
		foreach (PlayingCard aCard in aHand)
		{
			Console.WriteLine(aCard);
		}
			return;
	}

/***************************************************************************************************
 ***************************************************************************************************
            uuuuuuuuuuuuuuuuuuuu
          u" uuuuuuuuuuuuuuuuuu "u
        u" u$$$$$$$$$$$$$$$$$$$$u "u
      u" u$$$$$$$$$$$$$$$$$$$$$$$$u "u
    u" u$$$$$$$$$$$$$$$$$$$$$$$$$$$$u "u
  u" u$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$u "u
u" u$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$u "u
$ $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ $
$ $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ $
$ $$$" ... "$...  ...$" ... "$$$  ... "$$$ $
$ $$$u `"$$$$$$$  $$$  $$$$$  $$  $$$  $$$ $
$ $$$$$$uu "$$$$  $$$  $$$$$  $$  """ u$$$ $
$ $$$""$$$  $$$$  $$$u "$$$" u$$  $$$$$$$$ $
$ $$$$....,$$$$$..$$$$$....,$$$$..$$$$$$$$ $
$ $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ $
"u "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$" u"
  "u "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$" u"
    "u "$$$$$$$$$$$$$$$$$$$$$$$$$$$$" u"
      "u "$$$$$$$$$$$$$$$$$$$$$$$$" u"
        "u "$$$$$$$$$$$$$$$$$$$$" u"
          "u """""""""""""""""" u"
            """"""""""""""""""""

 ***************************************************************************************************
/***************************************************************************************************
/***************************************************************************************************
 *
 *   IMPORTANT: The code that follows is beyond what is taught in the basic C# class
 *
 *              It is provided to make the class more complete by providing reasonable
 *              functionality.
 *
 *   THIS CODE WILL NOT BE REVIEWED BY THE INSTRUCTOR IN CLASS.
 *
 *   You may review it on your own to gain an understanding of what it does, but the instructor
 *   will only entertain questions/review of this code as availability permits.
 *
/***************************************************************************************************
/***************************************************************************************************

/***************************************************************************************************
 * Methods to sort cards in a Hand using Collections class sort() method
 *
 * The Collection class sort() method provides a way to sort elements in any Collection class object
 *
 * We are using the Collections sort method that uses a Comparator object:
 *
 *            Collections.sort(Collection-object, Comparator-object)
 *
 * A Comparator object is an object of a class that implements
 *              the Comparator interface for the class of the objects to be compared
 *
 * The class of the Comparator object must override the compare() method.
 *
 * The compare method of the Comparator object class must receive two objects of the class to
 *              be compared and return and int representing the relationship of the two objects:
 *
 *              0 - Indicates objects were equal
 *             >0 - Indicates 1st object was greater than the second
 *             <0 - Indicates 1st object was less than the second
 *
 ***************************************************************************************************/

	public void SortByValue() {  // Sort cards by value using Collections sort() method
		aHand.Sort(new ValueCompare());
	}

	public void SortByColor() {  // Sort cards by Color using Collections sort() method
		aHand.Sort(new ColorCompare());
	}

	public void SortBySuit() {   // Sort cards by Suit using Collections sort() method
		aHand.Sort(new SuitCompare());
	}

	/***************************************************************************************************
	 * Embedded classes for Comparator objects used by sorting methods
	 ***************************************************************************************************/

	public class ValueCompare : IComparer<PlayingCard> {      // Compare two PlayingCards by value
		public int Compare(PlayingCard Card1, PlayingCard Card2) {
			return Card2.GetIntValue() - Card1.GetIntValue();
		}
	}

	public class SuitCompare : IComparer<PlayingCard> {       // Compare two PlayingCards by suit
		public int Compare(PlayingCard Card1, PlayingCard Card2) {
			return (int) Card1.Suit - (int) Card2.Suit;
		}
	}

	public class ColorCompare : IComparer<PlayingCard> {       // Compare two PlayingCards by color
		public int Compare(PlayingCard Card1, PlayingCard Card2) {
			return (int) Card1.Color - (int) Card2.Color;
		}
	}
}

