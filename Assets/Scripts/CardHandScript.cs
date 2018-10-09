using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandScript : MonoBehaviour {

	[SerializeField]
	private Transform cardPrefab, cardSpawner;

	[SerializeField]
	private float cardSpacing = 2.3f;

	private List<Transform> displayedCards = new List<Transform>();

	public void Display(CardData[] cards) {

		// clean the slate
		removeDisplayedCards();
		displayedCards = new List<Transform>();

		// place the first card at the cardSpawner's position
		Vector3 position = cardSpawner.position;

		foreach(CardData cardData in cards) {

			// create the card
			Transform card = Instantiate<Transform>(cardPrefab, position, Quaternion.identity);
			card.GetComponent<CardScript>().cardData = cardData;
			card.GetComponent<CardScript>().player = GetComponent<PlayerScript>();
			card.localScale = card.localScale * .75f;

			// find the next slot for the next card
			position += Vector3.right * cardSpacing;

			// keep track of the displayed card
			displayedCards.Add(card);

		}
	}

	private void removeDisplayedCards(){
		for(int i = 0; i < displayedCards.Count; i++){
			GameObject.Destroy(displayedCards[i].gameObject);
		}
	}
	
}
