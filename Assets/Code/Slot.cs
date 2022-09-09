using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    
    Item Item;
    [SerializeField] Image icon;
    public void SetItem(Item item)
    {
        Item = item;
        icon.sprite = Item.Icon;
    }
    public Item GetItem()
    {
        return Item;
    }
}
