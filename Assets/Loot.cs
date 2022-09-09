using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [HideInInspector] public List<LootItem> lootItems;
    [SerializeField] GameObject lootItemsPrefeb;

    void Start()
    {
        lootItems = new List<LootItem>();
    }


    public void addItems(Slot slot)
    {
        var selectedItem = slot.GetItem();
        bool isFinded = false;
        foreach (var item in lootItems)
        {
            if (item.lootIcon.sprite == selectedItem.Icon)
            {
                isFinded = true;
                if (selectedItem.CanGivePoint)
                {
                    item.lootPoint += selectedItem.currentPoint;
                }

                else
                {
                    item.lootPoint += 1;
                }

                item.lootText.text = "x" + item.lootPoint.ToString();
            }

        }
        if (!isFinded)
        {
            var newlootInstantiate = Instantiate(lootItemsPrefeb, transform);
            var newlootItem = newlootInstantiate.GetComponent<LootItem>();
            newlootItem.lootIcon.sprite = selectedItem.Icon;
            if (selectedItem.CanGivePoint)
            {
                newlootItem.lootPoint += selectedItem.currentPoint;
            }
            else
            {
                newlootItem.lootPoint += 1;
            }

            newlootItem.lootText.text = "x" + newlootItem.lootPoint.ToString();
            lootItems.Add(newlootItem);
        }
    }
}
