using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardScript : MonoBehaviour {

    public CardData cardData;
    public PlayerScript player;

    // current "stats"
    private float faith;            // sorta like health
    private float conversion_power; // sorta like damage / attack 

    private Vector3 hoverScale, regularScale, originalScale;

    private bool selected = false;

	void Start () {

        // initializing stats
        faith = cardData.faith;
        conversion_power = cardData.conversion_power;
        rerender();

        regularScale = transform.localScale;
        hoverScale = regularScale * 1.2f;
        originalScale = regularScale;
    }

    // update the data values on the card
    private void rerender() {

        // using the current conversion and faith stats
        // rather than relying on the cardData defaults
        transform.Find("Card Canvas/Conversion Power").GetComponent<TextMeshProUGUI>().text = "" + conversion_power;
        transform.Find("Card Canvas/Faith").GetComponent<TextMeshProUGUI>().text = "" + faith;

        // however the name and portrait sprite probably shouldn't
        // be changing, so we can just use the cardData defaults
        transform.Find("Portrait").GetComponent<SpriteRenderer>().sprite = cardData.portrait;
        transform.Find("Card Canvas/Name").GetComponent<TextMeshProUGUI>().text = cardData.name;
    }



    void OnMouseOver() {
        if(inSelectingMode()) {
            transform.localScale = hoverScale;
        }
    }

    void OnMouseExit() {
        transform.localScale = regularScale;
    }

    void OnMouseUp() {
        if(inSelectingMode()) {
            if(!selected) {
                // "permanently" highlight the card as selected
                player.Select(cardData);
                transform.localScale = hoverScale;
                regularScale = hoverScale;
                selected = true;
            } else {
                // unselect the card
                player.Deselect(cardData);
                transform.localScale = originalScale;
                regularScale = originalScale;
                selected = false;
            }
        }
    }
    private bool inSelectingMode() {
        return !player.isFinishedSelecting();
    }
}
