﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IPlayer {

	[SerializeField]
	private GameObject deckObject;
	private DeckScript deck;
	private List<CardData> cards;

	private float faith = 100f;

	// selecting mode
	List<CardData> selected;
	private bool isSelecting = false;
	[SerializeField]
	private Transform DoneSelectingButton;


	// Use this for initialization
	void Start () {		
		deck = deckObject.GetComponent<DeckScript>();
		DoneSelectingButton.gameObject.SetActive(false);
		cards = new List<CardData>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DrawCards(int numberOfCards){
		foreach(CardData card in deck.DrawCards(numberOfCards)){
			cards.Add(card);
		}
		GetComponent<CardHandScript>().Display(cards);
	}

	public void StartSelecting(){
		isSelecting = true;
		selected = new List<CardData>();
		DoneSelectingButton.gameObject.SetActive(true);
		GetComponent<CardHandScript>().Display(cards);
	}

	public bool isFinishedSelecting(){
		return !isSelecting;
	}

	public void FinishSelecting() {
		isSelecting = false;
		foreach(CardData card in selected){
			deck.Discard(card);
		}
		GetComponent<CardHandScript>().ClearDisplay();
	}

	public void Select(CardData card) {
		selected.Add(card);
		cards.Remove(card);		// remove card from hand
	}

	public void Deselect(CardData card) {
		selected.Remove(card);
		cards.Add(card);		// add it back to your hand
	}

	public CardData[] GetSelectedCards(){
		return selected.ToArray();
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
