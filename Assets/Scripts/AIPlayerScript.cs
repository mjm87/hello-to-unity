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
		int num = Random.Range(1,cards.Length-1)-1;
		selected = new CardData[num];
		for(int i = 0; i < num; i++) {
			selected[i] = cards[Random.Range(1,cards.Length-1)];
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
