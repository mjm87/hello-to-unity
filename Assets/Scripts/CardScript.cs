using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardScript : MonoBehaviour {

    public CardData portrait_data;


    // card display components
    private SpriteRenderer portraitRenderer;
    private TextMeshProUGUI conversionPowerText;
    private TextMeshProUGUI faithText;
    private TextMeshProUGUI nameText;


	void Start () {

        // finding the portrait related child components
        portraitRenderer = transform.Find("Portrait").GetComponent<SpriteRenderer>();
        conversionPowerText = transform.Find("Card Canvas/Conversion Power").GetComponent<TextMeshProUGUI>();
        faithText = transform.Find("Card Canvas/Faith").GetComponent<TextMeshProUGUI>();
        nameText = transform.Find("Card Canvas/Name").GetComponent<TextMeshProUGUI>();

        // initializing card with portrait_portrait_data
        portraitRenderer.sprite = portrait_data.portrait;
        conversionPowerText.text = "" + portrait_data.conversion_power;
        faithText.text = "" + portrait_data.faith;
        nameText.text = "" + portrait_data.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
