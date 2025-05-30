namespace Playing_Card_Poker_Game;

public class PlayingCard
{
    /***************************************************************************************************
     * Define constants to represent card attributes
     *
     * public is OK since they are constants and cannot be changed
     *
     * static so it can be referenced using the class name. i.e. no object required
     *
     * enum - define a set of constant values that may be referenced as a data type
     *        allows the assign of a word to a constant value to limit the values in a variable
     *        make it easier to code (get rid using "magic" numbers to represent data
     *        used as data-types - define variable as enums, parameters as enum - anywhere a variable is allowed
     *        C# will ensure that an enum type only has values valid for the enum (we don't have to check)
     *        enum are actual integer values starting at 0 inside C#
     ***************************************************************************************************/
    // Making the enum public allows application programs to use the enum as constant too

    public enum CardColor
    {  // define words to represent allowable card colors (instead of String)
        // 0  , 1  
        Black, Red                 // These are the only valid values C# will allow
    };

    public enum CardSuit
    {   // public is OK since they are constants and cannot be changed
        Spade, Club, Heart, Diamond, Joker  // These are the only valid values C# will allow
    };

    public enum CardValue
    {  // Using the fact that enums are really integers inside value to name our values
        //  0    1    2     3      4    5     6     7      8      9    10   11    12     13    14
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
     * static so it can be referenced using the class name. i.e. no object required
     *
     * readonly so it can't be changed - const is Ok too 
     ***************************************************************************************************/
//                            datatype  variable-name    = initial-value  ;
    protected static readonly CardValue DEFAULTCARDVALUE = CardValue.Joker;   // enum data-type for value
    protected static readonly CardColor DEFAULTCOLOR     = CardColor.Black;
    protected static readonly CardSuit  DEFAULTSUIT      = CardSuit.Joker;
    /***************************************************************************************************
     * Member data
     *
     * private to protect as prescribed by encapsulation - method must be used to access the data 
     ***************************************************************************************************/

    private CardValue _value;  // use enum for data type- C# will enforce allowable values
    private CardColor _color;  // use enum for data type- C# will enforce allowable values
    private CardSuit  _suit;   // use enum for data type- C# will enforce allowable values
    private bool      _faceUp; // true if card is face up; false if not   

    /***************************************************************************************************
     * Default constructor - in case it is needed
     ***************************************************************************************************/

    public PlayingCard()
    {
        _value = DEFAULTCARDVALUE;
        _suit  = DEFAULTSUIT;
        SetColor(_suit);     // Set color in object based on suit - NOTE: suit must have a value before this
        _faceUp = false;
    }
    /***************************************************************************************************
     * 2-arg (CardValue and CardSuit) constructor
     ***************************************************************************************************/
    public PlayingCard(CardValue value, CardSuit suit)
    {
        this._value = value;   // Set value in object to value passed as argument
        SetColor(suit);        // Set color in object based on suit passed as argument
        this._suit = suit;     // Set suit in object to suit passed as argument
        _faceUp = false;
    }
    /***************************************************************************************************
     * 2-arg (int and CardSuit) constructor
     ***************************************************************************************************/
    public PlayingCard(int value, CardSuit suit)
    {
        this._value = SetValue(value); // Set value in object based on int value passed as argument
        SetColor(suit);                // Set color in object based on suit passed as argument
        this._suit = suit;             // Set suit in object to suit passed as argument
        _faceUp = false;
    }
    /***************************************************************************************************
     * Properties - Used for others to access private data via getters and setters
     **************************************************************************************************/
    public CardValue Value
    {             get { return _value;  }
        protected set { _value = value; } // protected so only subclasses can change value
    }

    public CardColor Color { get; protected set; }  // set protected so only subclasses can change value

    public CardSuit Suit
    {
        get => _suit;
        protected set => _suit = value;   // protected so only subclasses can change value
    }

    public bool FaceUp { get; set; }

    /***************************************************************************************************
     * additional getter and setter methods
     ***************************************************************************************************/

    // Return the integer value assigned to the card - value is an enum called CardValue
    public int GetIntValue()
    {   // Return integer value of CardValue enum in a PlayingCard 
        return (int) _value;  // cast the enum to an int to get its integer value
    }

    public CardValue SetValue(int ivalue)
    {  // Set the CardValue based on an int value
        /***********************************************************************************************************
         * switch is alternative to a a set of nested if-then-else-if statements
         * switch is followed by a series of case statements which are the value you want to check in the variable
         * when a case is true the statements following the case AND ALL OTHER CASES are run too
         *        unless you have break at end of the case
         *        when a case is true all statements in the switch following the case are run until
         *        it hits a break statement or the end of the switch - no other cases are checked
         *
         * stacking cases to simulate an equals-or condition
         * There is not a way to simulate an equals-and in a switch
         *
         * switch(variable) { - check the value in this variable
         *      case value:  - if the value for the switch equales the case value
         *           statements-to-run if value in the case matches the Ace in the swutch
         *           break; - exit switch - if missing you will fall into next case
         *                    not required if case issues a return statement at end of case
         *      default: - if none of the cases were true
         *           statement-to-run if none of cases were true
         *           break; - exit switch - re   required on default case even though it is last
         * }
         *************************************************************************************************************/
        switch (ivalue)                  // Check ivalue
        {
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
        // if (suit == cardSuit.Spade or suit == cardSuit.Club) - stack cases does this
        switch (suit)
        {
            case CardSuit.Spade:       // Stacking cases simulates an equal or condition
            case CardSuit.Club:
                this._color = CardColor.Black;
                break;      // break is required so we don't fall through to the next case - we exit the switch
            case CardSuit.Diamond:
            case CardSuit.Heart:
                this._color = CardColor.Red;
                break;      // break is required so we don't fall through to the next case - we exit the switch
            default:
                this._color = DEFAULTCOLOR;  // break is needed here even through its last case
                break;
        }
    }

    public void Flip()  // reverse if card is face up or down
    {
        _faceUp = !_faceUp;
    }

    /***************************************************************************************************
     * Object super class overrides
     *
     *      ToString()    - represent class data as a String
     *      Equals()      - determine if contents of two object of the class are equal
     *      GetHashCode() - generate hash code based on unchanging data members
     * 
     ***************************************************************************************************/
    // Ask compiler to assure this is a valid super class override
    public override string ToString()
    { // Return a String representation of the object
        return $"Playing Card: Value={_value}({(int)_value})\tSuit={_suit}\tColor={_color}\tFace Up={_faceUp}";
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
    {   // Generate a hash Code for object if C# needs One e.g. for a HashMap
        // A hash code is a unique value representing an instance of an object
        // It is recommended to use member variables whose value is unlikely to change
        //
        // The HashCode class has a method called .Combine()
        //     which will generate a hash code from the values in the variable you send it
        //
        // The same variables used to determine object equality should be used
        //     when generating a hash code
        return HashCode.Combine(_value, _suit, _color);
    }

    /***************************************************************************************************
     * Miscellaneous class methods
     ***************************************************************************************************/
    public void ShowCard()
    {   // Display an instance of a PlayingCard
        Console.WriteLine(this.ToString());
    }

    public void ShowCardWithHash()
    {   // Display an instance of a PlayingCard with HashCode
        Console.WriteLine(this.ToString() + "\thashCode: " + GetHashCode());
    }
}  // End of PlayingCard Class