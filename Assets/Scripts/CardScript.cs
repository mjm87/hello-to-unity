using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardScript : MonoBehaviour {

    public CardData portrait_data;

	// Use this for initialization
	void Start () {
        // initializing card with portrait_portrait_data
        transform.Find("Portrait").GetComponent<SpriteRenderer>().sprite = portrait_data.portrait;
        transform.Find("Card Canvas/Conversion Power").GetComponent<TextMeshProUGUI>().text = "" + portrait_data.conversion_power;
        transform.Find("Card Canvas/Faith").GetComponent<TextMeshProUGUI>().text = "" + portrait_data.faith;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
