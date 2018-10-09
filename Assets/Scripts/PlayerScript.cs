using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IPlayer {

	[SerializeField]
	private GameObject deckObject;
	private DeckScript deck;

	// selecting mode
	List<CardData> selected;
	private bool isSelecting = false;
	[SerializeField]
	private Transform DoneSelectingButton;


	// Use this for initialization
	void Start () {		
		deck = deckObject.GetComponent<DeckScript>();
		DoneSelectingButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DrawCards(int numberOfCards){
		CardData[] cards = deck.DrawCards(numberOfCards);
		GetComponent<CardHandScript>().Display(cards);
	}

	public void StartSelecting(){
		isSelecting = true;
		selected = new List<CardData>();
		DoneSelectingButton.gameObject.SetActive(true);
	}

	public bool isFinishedSelecting(){
		return !isSelecting;
	}

	public void FinishSelecting() {
		isSelecting = false;
	}

	public void Select(CardData card) {
		selected.Add(card);
	}
}
