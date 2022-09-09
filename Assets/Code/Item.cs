using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " Items", menuName = "Items/Item")]
public class Item : ScriptableObject
   
{
    public long ID;
    public string ItemName;
    public Sprite Icon;
    public int MinPoint;
    public int MaxPoint;
    [HideInInspector]public int currentPoint;
    public bool CanGivePoint;
    public string RarityText;
    public string WeaponName;
    [Range(0,100)] public float Rarity;
    public Color BackgroundColor;


}
