using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerScript : MonoBehaviour, IPlayer {

	[SerializeField]
	private GameObject deckObject;
	private DeckScript deck;

	private float faith = 100f;

	private CardData[] selected;
	private CardData[] cards;

	// Use this for initialization 	
	void Start () {
		deck = deckObject.GetComponent<DeckScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DrawCards(int numberOfCards){
		cards = deck.DrawCards(numberOfCards);
	}

	public void StartSelecting() {
		// selecting how many cards to play (randomly)
		int num = Random.Range(1,cards.Length-1);

		List<int> selectedIndexes = new List<int>();
		selected = new CardData[num];

		// selecting the cards at random
		for(int i = 0; i < num; i++) {
			int randIdx = Random.Range(0,cards.Length-1);
			// but not including previously picked cards
			if(!selectedIndexes.Contains(randIdx)) {
				selected[i] = cards[randIdx];
				selectedIndexes.Add(randIdx);
			} else {
				i--;		// handling reselection in the case of collisions
			}

		}
	}

	public bool isFinishedSelecting() {
		return true;
	}

	public CardData[] GetSelectedCards() {
		foreach(CardData card in selected){
			deck.Discard(card);
		}
		return selected;
	}

	public void TakeDamage(float damage) {
		faith -= damage;
	}

	public bool isStillAlive() {
		return faith > 0f;
	}

	public float GetHealth(){
		return faith;
	}
}
