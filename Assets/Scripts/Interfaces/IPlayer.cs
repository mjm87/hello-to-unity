using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPlayer {

	void DrawCards(int number);
	void StartSelecting();
	bool isFinishedSelecting();
	
}
