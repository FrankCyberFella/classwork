using System.Runtime.InteropServices;

namespace Playing_Card_Poker_Game;

using System;
using System.Collections.Generic; // Required for List

/***************************************************************************************************
 * Class to Simulate an PokerHand using and American PlayingCard Hand
 *
 * PokerHand is a CardHand - "is-a" relationship - inheritance
 ***************************************************************************************************/

//         a PokerHand is-a CardHand
public class PokerHand  :   CardHand
{
/***************************************************************************************************
 * Member Data
 ***************************************************************************************************/
	/***************************************************************************************************
	 * Instance data
	 ***************************************************************************************************/
	private PokerHandRanking handRank; // Current rank of hand
	
	public PokerHandRanking  HandRank { get; private set; } 

	/***************************************************************************************************
	 * Constants
	 ***************************************************************************************************/
	public const int NUMBERCARDSINAHAND = 5; // Number of aHand in PokerHand

	public enum PokerHandRanking
	{
		// Hand rankings from low to high
		NotRanked,
		High_Card,
		Pair,
		Two_Pair,
		Three_Of_A_Kind,
		Straight,
		Flush,
		Full_House,
		Four_Of_A_Kind,
		Straight_Flush,
		Royal_Straight_Flush
	};

/***************************************************************************************************
 * Member methods
 ***************************************************************************************************/

	/***************************************************************************************************
	 * Constructor
	 ***************************************************************************************************/
	public PokerHand() : base()
	{
		// Default constructor
		handRank = PokerHandRanking.NotRanked;
	}

	public PokerHand(PokerHand otherHand) : base()
	{
		// copy constructor
		handRank = PokerHandRanking.NotRanked;

		for (int cardNum = 0; cardNum < NumCardsInHand; cardNum++)
		{
			// Loop thru source hand
			this.aHand.Add(otherHand.aHand[cardNum]); // Copy current source card to new hand
		}
	}

	/***************************************************************************************************
	 * getters
	 ***************************************************************************************************/
	public PokerHandRanking GetHandRank()
	{
		handRank = RankHand();
		return handRank;
	}


	/***************************************************************************************************
	 * Miscellaneous Member Methods
	 ***************************************************************************************************/
	public new void ClearHand()
	{
		// Remove all aHand from Hand
		base.ClearHand();
	}

	public override void DealHand(CardDeck aDeck)
	{
		// Deal a Hand
		for (int i = 0; i < NUMBERCARDSINAHAND; i++)
		{
			// For the number of aHand in hand
			base.aHand.Add(aDeck.DealCard()); //     Add a card from deck passed to hand
		}
	}

	/***************************************************************************************************
	 * Overrides
	 ***************************************************************************************************/

	public override void Show()
	{
		base.Show();
	}

	/****************************************************************************************************
	 * Determine Poker Rank of Hand
	 *
	 *  Note this is V0 version of the method - it could possibly be refactored to be better, but it works
	 ****************************************************************************************************/
	public PokerHandRanking RankHand()
	{
		PokerHand theHand = this;
		
		theHand.SortByValue();

		if (theHand.IsRoyalFlush())
		{
			HandRank = PokerHandRanking.Royal_Straight_Flush;
			return HandRank;
		}

		if (theHand.IsStraightFlush())
		{
			HandRank = PokerHandRanking.Straight_Flush;
			return HandRank;
		}

		if (theHand.IsFourOfAKind())
		{
			HandRank = PokerHandRanking.Four_Of_A_Kind;
			return HandRank;
		}

		if (theHand.IsFullHouse())
		{
			HandRank = PokerHandRanking.Full_House;
			return HandRank;
		}

		if (theHand.IsFlush())
		{
			HandRank = PokerHandRanking.Flush;
			return HandRank;
		}

		if (theHand.IsStraight())
		{
			HandRank = PokerHandRanking.Straight;
			return HandRank;
		}

		if (theHand.IsThreeOfAKind())
		{
			HandRank = PokerHandRanking.Three_Of_A_Kind;
			return HandRank;
		}

		if (theHand.IsTwoPair())
		{
			HandRank = PokerHandRanking.Two_Pair;
			return HandRank;
		}

		if (theHand.IsOnePair())
		{
			HandRank = PokerHandRanking.Pair;
			return HandRank;
		}

		HandRank = PokerHandRanking.High_Card;
		return HandRank;

	}

	public bool IsRoyalFlush()
	{
		return IsStraightFlush() && aHand[0].Value == PlayingCard.CardValue.Ace;
	}

	public bool IsStraightFlush()
	{
		return IsFlush() && IsStraight();
	}

	public bool IsFourOfAKind()
	{
		return aHand.GroupBy(c => c.Value).Any(g => g.Count() == 4);
	}

	public bool IsFullHouse()
	{
		var groups = aHand.GroupBy(c => c.Value).ToList();
		return groups.Any(g => g.Count() == 3) && groups.Any(g => g.Count() == 2);
	}

	public bool IsFlush()
	{
		return aHand.Select(c => c.Suit).Distinct().Count() == 1;
	}

	public bool IsStraight()
	{
		// Check for high Ace straight
		if (aHand[0].Value - aHand[4].Value == 4 && aHand.Select(c => (int)c.Value).Distinct().Count() == 5)
		{
			return true;
		}
		// Check for low Ace straight (A-2-3-4-5)
		if (aHand[0].Value    == PlayingCard.CardValue.Ace
		    && aHand[1].Value == PlayingCard.CardValue.Five
		    && aHand[2].Value == PlayingCard.CardValue.Four
		    && aHand[3].Value == PlayingCard.CardValue.Three
		    && aHand[4].Value == PlayingCard.CardValue.Two)
		{
			return true;
		}
		return false;
}

public bool IsThreeOfAKind()
    {
	    return aHand.GroupBy(c => c.Value).Any(g => g.Count() == 3);
    }
	public bool IsTwoPair()
	{
		return aHand.GroupBy(c => c.Value).Count(g => g.Count() == 2) == 2;
	}
	public bool IsOnePair()
	{
		return aHand.GroupBy(c => c.Value).Any(g => g.Count() == 2);
	}




/**************************************************************************************
* OLD VERSION!
********************************************************************************************************/
	public PokerHandRanking RankHand2()
	{
		this.SortByValue();

		handRank = PokerHandRanking.High_Card;

		if (HasFourOfAKind())
		{
			handRank = PokerHandRanking.Four_Of_A_Kind;
		}
		else if (HasThreeOfAKind())
		{
			if (HasOnePair())
			{
				handRank = PokerHandRanking.Full_House;
			}
			else handRank = PokerHandRanking.Three_Of_A_Kind;
		}
		else if (HasTwoPair())
		{
			handRank = PokerHandRanking.Two_Pair;
		}
		else if (HasOnePair())
		{
			if (HasThreeOfAKind())
			{
				handRank = PokerHandRanking.Full_House;
			}
			else handRank = PokerHandRanking.Pair;
		}

		if (HasFlush())
		{
			handRank = PokerHandRanking.Flush;
			if (HasStraight())
			{
				handRank = PokerHandRanking.Straight_Flush;
			}
		}

		if (HasStraight())
		{
			handRank = PokerHandRanking.Straight;
			if (HasFlush())
			{
				handRank = PokerHandRanking.Straight_Flush;
			}
		}

		if (((this.aHand[0].Value == PlayingCard.CardValue.Ace)
		     && (this.aHand[4].Value == PlayingCard.CardValue.King)
		     && (this.aHand[3].Value == PlayingCard.CardValue.Queen)
		     && (this.aHand[2].Value == PlayingCard.CardValue.Jack)
		     && (this.aHand[1].Value == PlayingCard.CardValue.Ten)
		    && HasFlush()))
		{
			handRank = PokerHandRanking.Royal_Straight_Flush;
		}

		return handRank;
	}
	/***************************************************************************************************
	 * Methods to rank a hand
	 *
	 * Note these are V0 versions of the methods - they could possibly be refactored to be better,
	 *      but they work
	 ***************************************************************************************************/

	private bool HasOnePair()
	{
		for (int i = 0; i < NUMBERCARDSINAHAND - 1; i++)
		{
			PlayingCard currentCard = new PlayingCard();
			currentCard = GetHand()[i];
			if (currentCard.Value == GetHand()[i + 1].Value)
			{
				return true;
			}
		}

		return false;
	}

	private bool HasTwoPair()
	{
		for (int i = 0; i < NUMBERCARDSINAHAND - 1; i++)
		{
			PlayingCard currentCard = new PlayingCard();
			currentCard = GetHand()[i];
			if ((currentCard.Value == GetHand()[i + 1].Value))
			{
				for (int j = i + 2; j < NUMBERCARDSINAHAND - 1; j++)
				{
					currentCard = GetHand()[j];
					if ((currentCard.Value == GetHand()[j + 1].Value))
					{
						return true;
					}
				}
			}
		}

		return false;
	}

	private bool HasThreeOfAKind()
	{
		for (int i = 0; i < NUMBERCARDSINAHAND - 2; i++)
		{
			PlayingCard currentCard = new PlayingCard();
			currentCard = GetHand()[i];
			if ((currentCard.Value == GetHand()[i + 1].Value)
			    && (currentCard.Value == GetHand()[i + 2].Value))
			{
				return true;
			}
		}

		return false;
	}

	private bool HasFourOfAKind()
	{
		for (int i = 0; i < NUMBERCARDSINAHAND - 3; i++)
		{
			PlayingCard currentCard = new PlayingCard();
			currentCard = GetHand()[i];
			if ((currentCard.Value == GetHand()[i + 1].Value)
			    && (currentCard.Value == GetHand()[i + 2].Value)
			    && (currentCard.Value == GetHand()[i + 3].Value))
			{
				return true;
			}
		}

		return false;
	}

	private bool HasFlush()
	{
		if ((GetHand()[0].Suit == GetHand()[1].Suit)
		    && (GetHand()[0].Suit == GetHand()[2].Suit)
		    && (GetHand()[0].Suit == GetHand()[3].Suit)
		    && (GetHand()[0].Suit == GetHand()[4].Suit))
		{
			return true;
		}
		else
			return false;
	}

	private bool HasStraight()
	{
		if ((GetHand()[1].GetIntValue()) == ((GetHand()[0].GetIntValue()) + 1)
		    && (GetHand()[2].GetIntValue() == ((GetHand()[1].GetIntValue()) + 1)
		        && (GetHand()[3].GetIntValue() == ((GetHand()[2].GetIntValue()) + 1)
		            && (GetHand()[4].GetIntValue() == ((GetHand()[3].GetIntValue()) + 1)))))
		{
			return true;
		}
		else
			return false;
	}

	private bool HasFullHouse()
	{
		PokerHand tempHand = new PokerHand(this);

		tempHand.SortByValue();

		if (this.HasThreeOfAKind())
		{
			this.SortByValue();

			if ((GetHand()[1].GetIntValue() == GetHand()[0].GetIntValue())
			 && (GetHand()[2].GetIntValue() == GetHand()[1].GetIntValue()))
			{
				if (GetHand()[3].GetIntValue() == GetHand()[4].GetIntValue())
				{
					return true;
				}
			}
		}

		return false;
	}
}



