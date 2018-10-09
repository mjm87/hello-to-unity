using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerScript : MonoBehaviour, IPlayer {

	[SerializeField]
	private GameObject deckObject;
	private DeckScript deck;

	private float faith = 100f;

	private CardData[] selected;

	// Use this for initialization 	
	void Start () {
		deck = deckObject.GetComponent<DeckScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DrawCards(int numberOfCards){
		CardData[] cards = deck.DrawCards(numberOfCards);
	}

	public void StartSelecting() {
		// todo: select card(s)
		// randomly???
		//TODO: determine how many to select
		//TODO: determine which cards to select
	}

	public bool isFinishedSelecting() {
		return true;
	}

	public CardData[] GetSelectedCards() {
		return selected;
	}

	public void TakeDamage(float damage) {
		faith -= damage;
	}
	public bool isStillAlive() {
		return faith > 0f;
	}
}
