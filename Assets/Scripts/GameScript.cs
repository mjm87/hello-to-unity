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

	}

	void Update () {
		

	/*
			1. Have two "player" objects assignable via inspector?
				- an object with a "playerScript" [or perhaps with a script implementing a Player interface]
			2. Draw cards from stack...
			3. Select cards to player
				- AI (random for now? heuristical?)
				- Player: select cards, press "Done"/"Finish Turn" whatever
			4. Play the round
			5. Replenish cards
			6. Rinse and repeat
	*/

	}
}
