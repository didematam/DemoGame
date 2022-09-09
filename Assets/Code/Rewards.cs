using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Rewards : MonoBehaviour
{

    [HideInInspector] public List<RewardItem> rewardItems;
    [SerializeField] GameObject rewardItemsPrefeb;
    [SerializeField] RectTransform rewardItemsAnimationPos;


    void Start()
    {
        rewardItems = new List<RewardItem>();
    }

   
    public Vector3 getPosofIcon(Slot slot)
    {
        Vector3 rewardItemPosition=Vector3.one;
        var selectedItem = slot.GetItem();
        bool isFinded = false;
        foreach (var item in rewardItems)
        {
            if (item.rewardIcon.sprite == selectedItem.Icon)
            {
                isFinded = true;
                rewardItemPosition = (item.rewardIcon.transform as RectTransform).position;
                
            }

        }
        if (!isFinded)
        {
            if (rewardItems.Count == 0)
            {
                rewardItemPosition = rewardItemsAnimationPos.position;
            }
            else
            {
                rewardItemPosition = (rewardItems.Last().rewardIcon.transform as RectTransform).position;
                rewardItemPosition = new Vector3(rewardItemPosition.x, rewardItemPosition.y - 100, rewardItemPosition.z);
            }
        }

        return rewardItemPosition;

    }

   
    public void addItems(Slot slot)
    {

        var selectedItem = slot.GetItem();
        bool isFinded = false;
        foreach(var item in rewardItems)
        {
            if (item.rewardIcon.sprite == selectedItem.Icon)
            {
                isFinded = true;
                if (selectedItem.CanGivePoint)
                {
                    item.rewardPoint += selectedItem.currentPoint;
                }
                    
                else
                {
                    item.rewardPoint += 1;
                }
                   
                item.rewardText.text="x"+ item.rewardPoint.ToString();
            }

        } 
        if(!isFinded)
        {
            var newRewardInstantiate = Instantiate(rewardItemsPrefeb, transform);
            var newRewardItem = newRewardInstantiate.GetComponent<RewardItem>();
            newRewardItem.rewardIcon.sprite = selectedItem.Icon;
            if (selectedItem.CanGivePoint)
            {
                newRewardItem.rewardPoint += selectedItem.currentPoint;
            }               
            else
            {
                newRewardItem.rewardPoint += 1;
            }
                
            newRewardItem.rewardText.text = "x" + newRewardItem.rewardPoint.ToString();
            newRewardItem.rewardSlot = slot;
            rewardItems.Add(newRewardItem);
            var rect =transform as RectTransform;
        }
    }
}
