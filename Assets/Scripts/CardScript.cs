using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {

    public CardData data;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = data.portrait;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
