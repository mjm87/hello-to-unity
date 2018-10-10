using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	[SerializeField]
	private GameObject Player1Object, Player2Object;
	private IPlayer player1;
	private IPlayer player2;
	private List<IPlayer> players = new List<IPlayer>();

	[SerializeField]
	private int startingNumberOfCards = 5;

	// Use this for initialization
	void Start () {	
		player1 = Player1Object.GetComponent<IPlayer>();
		player2 = Player2Object.GetComponent<IPlayer>();

		// kick off the game loop
		StartCoroutine(GameLoop());
	}

	private IEnumerator GameLoop(){

		// wait a tenth of a second to make sure everything is ready
		yield return new WaitForSeconds(0.1f);

		// each player draws their cards
		player1.DrawCards(startingNumberOfCards);
		player2.DrawCards(startingNumberOfCards);

		int round = 1;

		while (player1.isStillAlive() && player2.isStillAlive()) {

			// each player selects some cards
			player1.StartSelecting();
			player2.StartSelecting();
			yield return new WaitUntil( () => 
				player1.isFinishedSelecting() && 
				player2.isFinishedSelecting()
			);			

			// each player plays the cards
			CardData[] p1_cards = player1.GetSelectedCards();
			CardData[] p2_cards = player2.GetSelectedCards();

			// Temporary display of round via terminal output
			Debug.LogFormat("Round {0}", round++);
			Debug.Log("Player 1 played: ");
			foreach(CardData card in p1_cards){
				Debug.LogFormat("{0}: {1},{2}", card.name, card.conversion_power, card.faith);
			}
			Debug.Log("Player 2 played: ");
			foreach(CardData card in p2_cards){
				Debug.LogFormat("{0}: {1},{2}", card.name, card.conversion_power, card.faith);
			}

			int smallerHand = Mathf.Min(p1_cards.Length, p2_cards.Length);
			int largerHand = Mathf.Max(p1_cards.Length, p2_cards.Length);

			// resolve the round
			for(int i = 0; i < smallerHand; i++){

				CardData p1 = p1_cards[i];
				CardData p2 = p2_cards[i];

				float p1_dmg = p1.conversion_power - p2.faith;
				float p2_dmg = p2.conversion_power - p1.faith;

				if(p1_dmg > 0) player2.TakeDamage(p1_dmg);
				if(p2_dmg > 0) player1.TakeDamage(p2_dmg);
			}

			// handle remaining "saints"
			for(int i = smallerHand; i < largerHand; i++) {

				if(p2_cards.Length > p1_cards.Length) {
					player1.TakeDamage(p2_cards[i].conversion_power);
				} else {
					player2.TakeDamage(p1_cards[i].conversion_power);
				}
			}

			Debug.LogFormat("Player 1: {0}", player1.GetHealth());
			Debug.LogFormat("Player 2: {0}", player2.GetHealth());

			// draw next card
			player1.DrawCards(1);
			player2.DrawCards(1);
		}

		if(player1.isStillAlive()) Debug.Log("The computer won... Better luck next time.");
		else Debug.Log("Hey. You won! I knew you could do it.");
	}

	void Update () {
	}
	
}
