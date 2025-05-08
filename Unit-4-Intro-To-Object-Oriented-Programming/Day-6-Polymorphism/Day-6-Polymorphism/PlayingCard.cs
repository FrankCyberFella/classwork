using System;
using System.Collections.Generic;

namespace Day_6_Polymorphism
{
    // This is class to represent a simple PlayingCard
    // It's in the same namespace as the application (for now and for simplicity)
    //

    public class PlayingCard
    {
    /*********************************************************************
     * Data members (attributes, properties, variables)
     *********************************************************************/
        
        //--------------------------------------------------------------
        // Instance variables
        //
        // By convention, private, instance variable names start with _
        //--------------------------------------------------------------
        private int    _cardValue;
        private string _cardSuit;
        private string _cardColor;

        //---------------------------------------------------------------
        // Properties to allow controller access to instance variables
        // property name is the data member in PascalCase
        //
        // Adding protected to the setter allows only subclasses 
        //        of this class to change the value in teh variable
        //---------------------------------------------------------------
        public int    CardValue { get; protected set; } // Use default getter and setter
        public string CardSuit  { get; protected set; } // Use default getter and setter
        public string CardColor { get; protected set; } // Use default getter and setter
        /*********************************************************************
         * Method members (functions that operate on the class data)
         *********************************************************************/

        //---------------------------------------------------------------
        // Constructor to initialize all instance variables
        //
        // Note use of properties rather instance variables
        //---------------------------------------------------------------
        public PlayingCard(int theValue, string theSuit, string theColor)
        {
            CardValue = theValue; // initialize value to value passed 
            CardSuit  = theSuit;  // initialize suit to suit passed  
            CardColor = theColor; // initialize the color to the color passed
        }

        //---------------------------------------------------------------
        // a Copy constructor to create a copy of a PlayingCard from a PlayingCard
        //   (aka "deep copy")
        //
        //  Note use of properties rather instance variables
        //---------------------------------------------------------------
        public PlayingCard(PlayingCard sourceCard)
        {
            CardColor = sourceCard.CardColor;
            CardSuit  = sourceCard.CardSuit;
            CardValue = sourceCard.CardValue;
        }

        /**************************************************************************
         * Class methods define the behavior of the class
         *************************************************************************/

        /*************************************************************************
         * Method overrides to have class behave way we want not the default way
         *************************************************************************/
        /*
        * An override is substituting your processing for the default processing of a method
        *
        * the override keyword, tells C# this is an override for a default behavior
        *                       C# will check to be sure your override signature
        *                                           matches the default
        *
        * System methods you should override:
        *
        *     public string ToString()         - Return a string representation of an object
        *     public bool   Equals(object obj) - Determine if two objects are Equal
        *     public int    GetHashCode()      - Generate unique int value (HashCode) for object
        *                                        A HashCode is used by C# in certain cases
        *                                          to determine if two objects are equal
        **************************************************************************************/

        //------------------------------------------------------------------
        // Override the default ToString() method: public string ToString() 
        //
        // ToString() returns an object of the class as a string
        //
        //  Note use of properties rather instance variables
        //-----------------------------------------------------------------
        public override string ToString()
        {
            return $"PlayingCard: Value={CardValue}, Color={CardColor}, Suit={CardSuit}";
        }

        //---------------------------------------------------------------------
        // Override the default Equals() method: public bool Equals(object obj)
        // 
        // Equals() returns true to data members of two objects are equal
        //---------------------------------------------------------------------
        public override bool Equals(object otherObject)
        {
            if (otherObject.GetType() != this.GetType())  // If types differ...
            {
                return false;                             //     they can't be equal
            }

            if (otherObject == this)                      // if the same object...
            {
                return true;                              //    they must be equal
            }

            // Create a PlayingCard reference to generic object passed to method
            // so we can access the object's data members
            PlayingCard otherCard = (PlayingCard) otherObject;

            if (otherCard._cardValue == this._cardValue   // if all data
             && otherCard._cardSuit  == this._cardSuit    //    members are equal
             && otherCard._cardColor == this._cardColor)  //      between the objects...
            {
                return true;                              // they are equal   
            }
            return false;  // If none of the previous tests are true they must be unequal
        }
        //---------------------------------------------------------------------
        // Override the default GetHashCode method:  public int GetHashCode()
        //
        // GetHashCode() should return a unique value generated by the member data
        //
        // GetHashCode() is used by C# in certain situations to determine of two
        //                  objects are equal and when inserting an object in
        //                  a hash-based collection e.g. HashSet, HashTable. 
        //-------------------------------------------------------------------------
        public override int GetHashCode()
        {
            // A HashCode may be generated determining the sum of:
            //
            //     numeric values * prime-number
            //     string, bool, objects - Use System GetHashCode method
            return _cardValue * 17 + _cardColor.GetHashCode() + _cardSuit.GetHashCode();
        }

        public virtual void ShowCard()
        {
            Console.WriteLine(this);
        }
    }  // End of PlayingCard class
} // End of namespace