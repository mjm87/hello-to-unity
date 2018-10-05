using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardScript : MonoBehaviour {

    public CardData cardData;


    // card display components
    private SpriteRenderer portraitRenderer;
    private TextMeshProUGUI conversionPowerText;
    private TextMeshProUGUI faithText;
    private TextMeshProUGUI nameText;

    // current "stats"
    private float faith;            // sorta like health
    private float conversion_power; // sorta like damage / attack 

	void Start () {

        // finding the portrait related child components
        portraitRenderer = transform.Find("Portrait").GetComponent<SpriteRenderer>();
        conversionPowerText = transform.Find("Card Canvas/Conversion Power").GetComponent<TextMeshProUGUI>();
        faithText = transform.Find("Card Canvas/Faith").GetComponent<TextMeshProUGUI>();
        nameText = transform.Find("Card Canvas/Name").GetComponent<TextMeshProUGUI>();

        // initializing stats
        faith = cardData.faith;
        conversion_power = cardData.conversion_power;

        // initializing the card portrait
        rerender();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void rerender() {
        // using the current conversion and faith stats
        // rather than relying on the defaults
        conversionPowerText.text = "" + conversion_power;
        faithText.text = "" + faith;

        // however the name and portrait sprite probably shouldn't
        // be changing, so we can just use the defaults
        portraitRenderer.sprite = cardData.portrait;
        nameText.text = "" + cardData.name;
    }
}
