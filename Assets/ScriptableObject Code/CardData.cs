using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Create New Card")]
public class CardData : ScriptableObject
{
    public Sprite portrait;
    public float conversion_power;
    public float faith;
    public string name;
	
    // private float currentFaith;
}
