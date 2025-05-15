using System.Text;

namespace Playing_Card_Poker_Game;

public class PlayingCard
{
    /***************************************************************************************************
     * Define constants to represent card attributes
     * 
     * public is OK since they are constants and cannot be changed
     * 
     * static so it can be referenced using the class name. ie. no object required
     * 
     * enum - define a set of constant values that may be referenced as a data type
     *        allows the assign of a word to a constant value to limit the values in a variable
     *        make it easier to code (get rid uysing "maigic" numbers to represent data
     *        used as data-types - define variable as enums, parameters as enum - any where a variable is allowed
     *        C# will ensure that an enum type only has values valid for teh enum (we don't have to check)
     *        enum are actual integer values starting at 0 inside C#
     ***************************************************************************************************/
    // MaKing the enum public allows application programs to use the enum as constant too

    public enum CardColor
    {  // define words to represent allowable card colors (instead of String)
        Black, Red                 // These are the only valid values C# will allow
    };

    public enum CardSuit
    {   // public is OK since they are constants and cannot be changed
        Spade, Club, Heart, Diamond, Joker  // These are the only valid values C# will allow
    };

    public enum CardValue
    {  // Using the fact that enums are really integers inside value to name our values
        Joker, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    };

    /***************************************************************************************************
     * Define constants to represent defaults for card attributes
     *
     * protected means members of this class and members of any subclass can access the data / method
     *           directly without having to use methods to do so
     *
     * protected so subclasses may access is OK since they are constants and cannot be changed
     * 
     * static so it can be referenced using the class name. ie. no object required
     ***************************************************************************************************/

    protected static readonly CardValue DEFAULTCARDVALUE = CardValue.Joker;   // enum data-type for value
    protected static readonly CardColor DEFAULTCOLOR = CardColor.Black;
    protected static readonly CardSuit  DEFAULTSUIT = CardSuit.Joker;
    /***************************************************************************************************
     * Member data
     * 
     * private to protect as prescribed by encapsulation - method must be used to access the data 
     ***************************************************************************************************/

    private CardValue _value;   // use enum for data type- C# will enforce allowable values
    private CardColor _color;   // use enum for data type- C# will enforce allowable values
    private CardSuit  _suit;    // use enum for data type- C# will enforce allowable values

    /***************************************************************************************************
     * Properties
     **************************************************************************************************

     public CardValue Value {get; set;}
     public CardValue Color {get; set;}
     public CardValue Suit  {get; set;}



    /***************************************************************************************************
     * Default constructor
     ***************************************************************************************************/

    public PlayingCard()
    {
        _value = DEFAULTCARDVALUE;
        _suit = DEFAULTSUIT;
        SetColor(_suit);     // Set color in object based on suit - NOTE: suit must have a value before this
    }
    /***************************************************************************************************
     * 2-arg (CardValue and CardSuit) constructor
     ***************************************************************************************************/
    public PlayingCard(CardValue value, CardSuit suit)
    {
        this._value = value;   // Set value in object to value passed as argument
        SetColor(suit);       // Set color in object based on suit passed as argument
        this._suit = suit;     // Set suit in object to suit passed as argument
    }
    /***************************************************************************************************
     * 2-arg (int and CardSuit) constructor
     ***************************************************************************************************/
    public PlayingCard(int value, CardSuit suit)
    {
        this._value = SetValue(value); // Set value in object based on int value passed as argument
        SetColor(suit);                // Set color in object based on suit passed as argument
        this._suit = suit;             // Set suit in object to suit passed as argument
    }
    /***************************************************************************************************
     * Properties
     **************************************************************************************************/
    public CardValue Value 
    {             get { return _value;  }
        protected set { _value = value; } // protected so only subclasses can change value
    }

    public CardColor Color { get; protected set; }  // set protected so only subclasses can change value
    //{
     //             get { return _color;  }
     //   protected set { _color = value; }  // protected so only subclasses can change value
    //}

    public CardSuit Suit
    {
               get => _suit;
     protected set => _suit = value;   // protected so only subclasses can change value
    }
    /***************************************************************************************************
     * additional getter and setter methods
     ***************************************************************************************************/
   
    // Return the integer value assigned to the card - value is a enum called CardValue
    public int GetIntValue()
    {   // Return integer value of CardValue enum in a PlayingCard 
        return (int) _value;  // cast the enum to an int to get its integer value
    }
    public CardValue SetValue(int ivalue)
    {  // Set the CardValue based on an int value
       /*
        * switch is alternative to a a set of nested if-then-else-if statements
        * switch is followed by a series of case statements which are the value you want to check in the variable
        * when a case is true the statements following the case AND ALL OTHER CASES are run too
        *        unless you have break at end of the case
        *        when a case is true all statements in the switch following the case are run until
        *        it hits a break statement or the end of the switch - no other cases are checked
        *
        * stacKing cases to simulate an equala-or condition
        * There is not a way to simulate an equals-and in a switch
        *
        * switch(variable) { - check the value in this variable
        *      case value:  - if the value for the switch equales the case value
        *           statements-to-run if value in the case matches the Ace in the swutch
        *
        *      default: - if none of teh cases were true
        *           statement-to-run if none of cases were true
        * }
        *
        * if the code below was writTen as a set of nested if-then-else-if
        *
        *  if (ivalue == 1) {
        *     return CardValue.Ace;
        *  }
        *  else if (ivalue == 2 {
        *           return cardValue.Two;
        *       }
        *       else if (ivalue == 3 {
        *               return cardValue.Three;
        *            }
        *            else if (ivalue == 4 {
        *                     return cardValue.Four;
        *                 }
        */
        switch (ivalue)
        { // Check ivalue
            case 1:                      // if ivalue == 1
                return CardValue.Ace;    //     do this
            case 2:                      // if ivalue == 2
                return CardValue.Two;    //      do this
            case 3:                      // ivalue == 3
                return CardValue.Three;  //      do this
            case 4:
                return CardValue.Four;
            case 5:
                return CardValue.Five;
            case 6:
                return CardValue.Six;
            case 7:
                return CardValue.Seven;
            case 8:
                return CardValue.Eight;
            case 9:
                return CardValue.Nine;
            case 10:
                return CardValue.Ten;
            case 11:
                return CardValue.Jack;
            case 12:
                return CardValue.Queen;
            case 13:
                return CardValue.King;
            default:
                return CardValue.Joker;
        }
    }

    private void SetColor(CardSuit suit)
    {  // Set the color based on the suit of the object
       // if (suit == cardSuit.Spade or suit == cardSuit.Club - stack cases does this
        switch (suit)
        {
            case CardSuit.Spade:       // StacKing cases simulates an equal or condition
            case CardSuit.Club:
                this._color = CardColor.Black;
                break;      // break is required so we don't fall through to the next case - we exit the switch
            case CardSuit.Diamond:
            case CardSuit.Heart:
                this._color = CardColor.Red;
                break;      // break is required so we don't fall through to the next case - we exit the switch
            default:
                this._color = DEFAULTCOLOR;  // no break is needed here because it is the last case
                break;
        }
    }

    /***************************************************************************************************
     * Object super class overrides
     ***************************************************************************************************/
    // Ask compiler to assure this is a valid super class override
    public override string ToString()
    { // Return a String representation of the object
      //-------------------------------------------------------------------------------------------------
      // StringBuilder is a mutable version of String - allows a new value to be assigned to the same String
      //              a more efficient type than String
      //
      // It's just a regular class, not a special data type like string,
      //                      so C# has no built-in support for it
      //
      //  To concaTenate values: String + String - C# knows that + with a String means concaTenation
      //                         StringBuilder.append(otherString) - methods are required
      //
      // String are immutable - if you assign a new value to a String C# destroy old String and creates a new Ace
      //-------------------------------------------------------------------------------------------------
        StringBuilder stringCard = new StringBuilder();  // Define an object to hold String version of object

        int firstColumnSize = 16;                      // position of first tab position of screen line 

        stringCard.Append("Value: " + _value);          // Add literal to StringBuffer
        stringCard.Append(" (" + GetIntValue() + ")"); // Add integer value of CardValue to StringBuffer
        if (stringCard.Length < firstColumnSize)
        {   // If current StringBuffer size less than first tab position
            stringCard.Append("\t");                   //     tab to first tab position
        }
        stringCard.Append("\tSuit: " + _suit);          // Add tab and suit value
        stringCard.Append("\tColor: " + _color);        // Add tab and color value
        return stringCard.ToString();                  // Convert StringBuffer to String and return
    }

    // Ask compiler to assure this is a valid super class override
    public override bool Equals(object otherObject)
    {   // Compare Two PlayingCards for equality - note generic Object parameter

        if (otherObject == this)
        {   // if object being compared to itself
            return true;             // objects are equal
        }
        else
        {
            // 'is' returns true if an object is an instance of the class specified
            if ((otherObject is PlayingCard))
            {   // If the object being compared to is the same class as object 
                PlayingCard otherCard = (PlayingCard)otherObject; // Define a PlayingCard object from object being compared to
                return (this._value == otherCard._value && this._color == otherCard._color && this._suit == otherCard._suit);
            }
            return false;    // Required so IDE realizes all logic paths are closed
        }
    }
    // Ask compiler to assure this is a valid super class override
    public override int GetHashCode()
    {      // Generate hashCode for object if C# needs Ace e.g. for a HashMap
           // HashCode is a unique value representing an instance of an object
        int hashValue = 17;      // A prime number used in calculating the HashCode
        int primeMultipler = 59; // A prime numbet used in calculating the HashCode

        hashValue = hashValue * primeMultipler + (int)_value;  // Same values used in equals() 
        hashValue = hashValue * primeMultipler + (int)_suit;   //     should be used in the 
        hashValue = hashValue * primeMultipler + (int)_color;  //        HashCode method
        return hashValue;
    }

    /***************************************************************************************************
     * Miscellaneous class methods
     ***************************************************************************************************/
    public void ShowCard()
    {   // Display an instance of a PlayingCard
        System.Console.WriteLine(this.ToString());
    }

    public void ShowCardWithHash()
    {   // Display an instance of a PlayingCard wirh HashCode
        System.Console.WriteLine(this.ToString() + "\thashCode: " + GetHashCode());
    }
}