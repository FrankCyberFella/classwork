// namespace Playing_Card_Poker_Game;  // C# groups things in namespaces
package PlayingCard; // Java groups things in package - package name must match the folder name for the package

import java.util.Objects;
// Just like in C#. Java class names are in PascalCase
// When you see a name starting in uppercase - it is a class
// When you see a name starting in lowercase - it is a variable or object
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
     *        Java will ensure that an enum type only has values valid for the enum (we don't have to check)
     *        enum are actual integer values starting at 0 inside C#
     ***************************************************************************************************/
    // Making the enum public allows application programs to use the enum as constant too

    public enum CardColor
    {  // define words to represent allowable card colors (instead of String)
        // 0  , 1  
        Black, Red                 // These are the only valid values C# will allow
    }  // C# required a ; at closing brace of enum; Java doesn't

    public enum CardSuit
    {   // public is OK since they are constants and cannot be changed
        Spade, Club, Heart, Diamond, Joker  // These are the only valid values C# will allow
    }

    public enum CardValue
    {  // Using the fact that enums are really integers inside value to name our values
        //  0    1    2     3      4    5     6     7      8      9    10   11    12     13    14
        Joker, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }

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
     *   C#: readonly so it can't be changed - const is Ok too 
     * Java: final so it can't be changed
     ***************************************************************************************************/
//                            datatype  variable-name    = initial-value  ;
    protected static final CardValue DEFAULTCARDVALUE = CardValue.Joker;   // enum data-type for value
    protected static final CardColor DEFAULTCOLOR     = CardColor.Black;
    protected static final CardSuit  DEFAULTSUIT      = CardSuit.Joker;
    /***************************************************************************************************
     * Member data
     *
     * private to protect as prescribed by encapsulation - method must be used to access the data 
     * 
     *   C#: private variable name starts with _ by convention
     * Java: has no convention for naming private variables
     ***************************************************************************************************/

    private CardValue value;  // use enum for data type- C# will enforce allowable values
    private CardColor color;  // use enum for data type- C# will enforce allowable values
    private CardSuit  suit;   // use enum for data type- C# will enforce allowable values
    //   C#: bool
    // Java: boolean
    private boolean   faceUp; // true if card is face up; false if not   

    /***************************************************************************************************
     * Default constructor - in case it is needed
     ***************************************************************************************************/

    public PlayingCard()
    {
        value = DEFAULTCARDVALUE;
        suit = DEFAULTSUIT;
        setColor(suit);     // Set color in object based on suit - NOTE: suit must have a value before this
        faceUp = false;
    }
    /***************************************************************************************************
     * 2-arg (CardValue and CardSuit) constructor
     ***************************************************************************************************/
    public PlayingCard(CardValue value, CardSuit suit)
    {
        this.value = value;   // Set value in object to value passed as argument
        setColor(suit);        // Set color in object based on suit passed as argument
        this.suit = suit;     // Set suit in object to suit passed as argument
        faceUp = false;
    }
    /***************************************************************************************************
     * 2-arg (int and CardSuit) constructor
     ***************************************************************************************************/
    public PlayingCard(int value, CardSuit suit)
    {
        // to convert an int to enum
        this.value = setValue(value); // Set value in object based on int value passed as argument
        setColor(suit);               // Set color in object based on suit passed as argument
        this.suit = suit;             // Set suit in object to suit passed as argument
        faceUp = false;
    }
    /***************************************************************************************************
     * C# Only: Properties - Used for others to access private data via getters and setters
     * Java does not support properties
     * Java requires specific getter and setter methods for each private variables
     **************************************************************************************************/
    /***************************************************************************************************
     * Standard  getter and setter methods
     ***************************************************************************************************/
    public CardValue getValue() {
        return value;
    }

    public void setValue(CardValue value) {
        this.value = value;
    }

    public CardColor getColor() {
        return color;
    }

    public void setColor(CardColor color) {
        this.color = color;
    }

    public CardSuit getSuit() {
        return suit;
    }

    public void setSuit(CardSuit suit) {
        this.suit = suit;
    }

    public boolean isFaceUp() {
        return faceUp;
    }

    public void setFaceUp(boolean faceUp) {
        this.faceUp = faceUp;
    }

    /***************************************************************************************************
     *   C#: MethodNames are Pascal case (start with uppercase letter)
     *       Opening brace for the method is on the next line from method signature
     *       (same if true for any statement that hase a block - if, while, switch etc)
     *
     * Java: methodNames are in camelCase (start with lowercase letter)
     *       (except constructor which always has same nae as class (PascalCase)
     *
     *       Opening brace for the method is on the same line as method signature
     *       (same if true for any statement that hase a block - if, while, switch etc)
     ***************************************************************************************************/
    /***************************************************************************************************
     * additional getter and setter methods
     ***************************************************************************************************/

    // Return the integer value assigned to the card - value is an enum called CardValue
    public int getIntValue() {   // Return integer value of CardValue enum in a PlayingCard
     // return (int) value;  //   C#: cast the enum to an int to get its integer value
        return value.ordinal(); // Java: .ordinal() method return the enums int value
    }

    public CardValue setValue(int ivalue) {  // Set the CardValue based on an int value
        /***********************************************************************************************************
         * switch is alternative to a set of nested if-then-else-if statements
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
         *           break; - exit switch -   C#: required on default case even though it is last
         *                                  Java: does not require break on default case
         * }
         *************************************************************************************************************/
        switch (ivalue)  { // check ivlue
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

    private void setColor(CardSuit suit) {  // Set the color based on the suit of the object
        // if (suit == cardSuit.Spade or suit == cardSuit.Club) - stack cases does this
        switch (suit) {
            case CardSuit.Spade:       // Stacking cases simulates an equal or condition
            case CardSuit.Club:
                this.color = CardColor.Black;
                break;      // break is required so we don't fall through to the next case - we exit the switch
            case CardSuit.Diamond:
            case CardSuit.Heart:
                this.color = CardColor.Red;
                break;      // break is required so we don't fall through to the next case - we exit the switch
            default:
                this.color = DEFAULTCOLOR;  // break is optional here in Java
                break;
        }
    }

    public void flip()  { // reverse if card is face up or down
        faceUp = !faceUp;
    }

    /***************************************************************************************************
     * Object super class overrides
     *
     *      toString()    - represent class data as a String
     *      equals()      - determine if contents of two object of the class are equal
     *      hashCode()    - generate hash code based on unchanging data members
     * 
     ***************************************************************************************************/
    @Override
    public String toString() {
        return "PlayingCard{" +
                "value=" + value +
                ", color=" + color +
                ", suit=" + suit +
                ", faceUp=" + faceUp +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (!(o instanceof PlayingCard that)) return false;
        return faceUp == that.faceUp && value == that.value && color == that.color && suit == that.suit;
    }

    @Override
    public int hashCode() {
        return Objects.hash(value, color, suit, faceUp);
    }

    /***************************************************************************************************
     * Miscellaneous class methods
     ***************************************************************************************************/
    public void ShowCard()
    {   // Display an instance of a PlayingCard
        // C#: Console.WriteLine() to display to screen

        //  object.method() - C#: Console is an object defined by C3; WriteLine is a method() for Console
        // Console.WriteLine(this.ToString());

        //       class.object.method - System is class defined by Java; out is an object defined by Java
        //                             println() is method defined in the System class (or subclass)
        // Java: System.out.printlin()
        System.out.println(this.toString());
    }

    public void ShowCardWithHash()
    {   // Display an instance of a PlayingCard with HashCode

        //Console.WriteLine(this.ToString() + "\thashCode: " + GetHashCode());
        System.out.println(this.toString() + "\thashCode: " + hashCode());
    }
}  // End of PlayingCard Class