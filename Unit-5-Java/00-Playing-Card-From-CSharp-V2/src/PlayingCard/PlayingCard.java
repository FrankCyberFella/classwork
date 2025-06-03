package PlayingCard;

import java.util.Objects;

public class PlayingCard
{
    public enum CardColor
    {   // define words to represent allowable card colors (instead of String)
        // 0  , 1  
        Black, Red                 // These are the only valid values Java will allow
    }

    public enum CardSuit
    {   // public is OK since they are constants and cannot be changed
        Spade, Club, Heart, Diamond, Joker  // These are the only valid values Java will allow
    }

    public enum CardValue
    {  // Using the fact that enums are really integers inside value to name our values
        //  0    1    2     3      4    5     6     7      8      9    10   11    12     13    14
        Joker, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    };

    protected static final CardValue DEFAULTCARDVALUE = CardValue.Joker;   // enum data-type for value
    protected static final CardColor DEFAULTCOLOR     = CardColor.Black;
    protected static final CardSuit  DEFAULTSUIT      = CardSuit.Joker;

    private CardValue value;  // use enum for data type- C# will enforce allowable values
    private CardColor color;  // use enum for data type- C# will enforce allowable values
    private CardSuit  suit;   // use enum for data type- C# will enforce allowable values
    private boolean   faceUp; // true if card is face up; false if not

    /***************************************************************************************************
     * Default constructor - in case it is needed
     ***************************************************************************************************/
    public PlayingCard() {
        value = DEFAULTCARDVALUE;
        suit  = DEFAULTSUIT;
        setColor(suit);     // Set color in object based on suit - NOTE: suit must have a value before this
        faceUp = false;
    }
    /***************************************************************************************************
     * 2-arg (CardValue and CardSuit) constructor
     ***************************************************************************************************/
    public PlayingCard(CardValue value, CardSuit suit) {
        this.value = value;   // Set value in object to value passed as argument
        setColor(suit);        // Set color in object based on suit passed as argument
        this.suit = suit;     // Set suit in object to suit passed as argument
        faceUp = false;
    }
    /***************************************************************************************************
     * 2-arg (int and CardSuit) constructor
     ***************************************************************************************************/
    public PlayingCard(int value, CardSuit suit) {
        this.value = setValue(value); // Set value in object based on int value passed as argument
        setColor(suit);                // Set color in object based on suit passed as argument
        this.suit = suit;             // Set suit in object to suit passed as argument
        faceUp = false;
    }
    /***************************************************************************************************
     * Standard Getters and Setters
     ***************************************************************************************************/
    public CardValue getValue() {
        return value;
    }
    public void      setValue(CardValue value) {
        this.value = value;
    }
    public CardColor getColor() {
        return color;
    }
    public void      setColor(CardColor color) {
        this.color = color;
    }
    public CardSuit  getSuit() {
        return suit;
    }
    public void      setSuit(CardSuit suit) {
        this.suit = suit;
    }
    public boolean   isFaceUp() {
        return faceUp;
    }
    public void      setFaceUp(boolean faceUp) {
        this.faceUp = faceUp;
    }

    /***************************************************************************************************
     * Additional getter and setter methods
     ***************************************************************************************************/

    // Return the integer value assigned to the card - value is an enum called CardValue
    public int getIntValue()
    {   // Return integer value of CardValue enum in a PlayingCard 
        // return (int) value;  // C# - cast the enum to an int to get its integer value
        return value.ordinal(); // Use the enum method ordinal to get its integer value
    }

    public CardValue setValue(int ivalue)  {  // Set the CardValue based on an int value

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

    private void setColor(CardSuit suit) {  // Set the color based on the suit of the object
        // if (suit == cardSuit.Spade or suit == cardSuit.Club) - stack cases does this
        switch (suit)
        {
            case Spade:       // Stacking cases simulates an equal or condition
            case Club:
                this.color = CardColor.Black;
                break;      // break is required so we don't fall through to the next case - we exit the switch
            case Diamond:
            case Heart:
                this.color = CardColor.Red;
                break;      // break is required so we don't fall through to the next case - we exit the switch
            default:
                this.color = DEFAULTCOLOR;  // break is needed here even through its last case
                break;
        }
    }

    public void flip() {  // reverse if card is face up or down
        faceUp = !faceUp;
    }

    /***************************************************************************************************
     * Object super class overrides:
     *
     *      ToString()    - represent class data as a String
     *      Equals()      - determine if contents of two object of the class are equal
     *      GetHashCode() - generate hash code based on unchanging data members
     ***************************************************************************************************/

    @Override
    public String toString() {    // Note in Java String is spelled with capital 'S'
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
    public void showCard() {   // Display an instance of a PlayingCard
        // C#: Console.WriteLine()
        // Java: System.out.println()
        System.out.println(this.toString());
    }

    public void showCardWithHash() {   // Display an instance of a PlayingCard with HashCode
        // C#: Console.WriteLine()
        // Java: System.out.println()
        System.out.println(this.toString() + "\thashCode: " + hashCode());
    }
}  // End of PlayingCard Class

