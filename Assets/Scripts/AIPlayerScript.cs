using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerScript : MonoBehaviour, IPlayer {

	[SerializeField]
	private GameObject deckObject;
	private DeckScript deck;

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
}
