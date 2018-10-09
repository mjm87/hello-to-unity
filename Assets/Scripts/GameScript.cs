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
		players.Add(player1);
		players.Add(player2);

		foreach(IPlayer p in players){
			p.DrawCards(startingNumberOfCards);
		}
		
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
