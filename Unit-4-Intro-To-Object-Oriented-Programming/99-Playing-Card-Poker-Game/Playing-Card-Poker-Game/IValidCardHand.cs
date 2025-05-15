namespace Playing_Card_Poker_Game;

/**************************************************************************************************************
 * An interface identifies methods that must be defined by class implementing the interface
 *
 * Think it as behaviors a class must exhibit to be a type of the interface
 *
 * An interface only contains method signatures followed by a colon - no body/code in the methods
 *************************************************************************************************************/

public interface IValidCardHand
{

    void ClearHand();                // Remove all cards from a hand
    void Show();                     // Display all cards in a hand
    void DealHand(CardDeck aDeck);   // Fill a hand from a CardDeck object
    void AddCard(PlayingCard aCard); // Add card to a hand
}
