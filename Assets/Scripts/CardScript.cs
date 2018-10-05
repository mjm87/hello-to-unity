using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardScript : MonoBehaviour {

    public CardData data;

	// Use this for initialization
	void Start () {
        transform.Find("Portrait").GetComponent<SpriteRenderer>().sprite = data.portrait;
        transform.Find("Card Canvas/Conversion Power").GetComponent<TextMeshProUGUI>().text = "" + data.conversion_power;
        transform.Find("Card Canvas/Faith").GetComponent<TextMeshProUGUI>().text = "" + data.faith;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
