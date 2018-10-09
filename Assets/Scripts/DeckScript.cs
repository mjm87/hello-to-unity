using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour {

	[SerializeField]
	private List<CardChance> cardChances;


	// the actual deck to draw cards from
	private Stack<CardData> deck;
	private Stack<CardData> discardPile;


	// number of times the program "reshuffles"
	// the higher times the more "random"??
	public int shuffleIterations = 1;

	// Use this for initialization
	void Awake () {

		// building the deck
		List<CardData> tempDeck = new List<CardData>();
		foreach(CardChance c in cardChances){
			for(int i = 0; i < c.count; i++){
				tempDeck.Add(c.card);
			}
		}

		// create a randomized deck to use
		deck = getRandomDeck(tempDeck.ToArray());

		// initialize the discard pile
		discardPile = new Stack<CardData>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public CardData[] DrawCards(int number) {
		CardData[] cards = new CardData[number];
		for(int i = 0; i < number; i++){
			
			// if there are cards left
			if(deck.Count > 0) {
				// grab one
				cards[i] = deck.Pop();
			} else {
				// otherwise swap the discard pile and the now empty deck
				// and reshuffle before continuing
				deck = getRandomDeck(discardPile.ToArray());
				discardPile = new Stack<CardData>();
				if(deck.Count > 0){
					cards[i] = deck.Pop();
				} else {
					// this should only occur if all cards happen to be in use
					// which theoretically should never happen?
					Debug.Log("Congratulations, you broke the game!");
				}
			}
		}

		return cards;
	}

	public void Discard(CardData card){
		discardPile.Push(card);
	}

	// essentially just binding together the card type and the number of cards in the deck
	// for ease of assignment in the editor
	[System.Serializable]
	struct CardChance {
		public CardData card;
		public int count;
	}

	private Stack<CardData> getRandomDeck(CardData[] originalDeck)
	{
		CardData[] deck = originalDeck;

		// shuffling the deck (repeatedly)
		for(int i = 0; i < shuffleIterations; i++){
			deck = shuffle(deck);
		}
		
		// return the stack equivalent
		return new Stack<CardData>(deck);
	}

	// randomly swap cards in the deck
	private CardData[] shuffle(CardData[] deck) {
		for(int i = 0; i < deck.Length; i++){
			// randomly choose a card to swap with
			int randomIndex = Random.Range(0,deck.Length);
			CardData swapped = deck[randomIndex];
			// swap the two cards
			deck[randomIndex] = deck[i];
			deck[i] = swapped;
		}
		return deck;
	}
}
