using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PopUpCardController : MonoBehaviour
{
    public Image background;
    public Image altColor;
    public Image weaponColor;
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI pointerText;


    public void SetProperty(Slot slot,float rewardPercentage, float currLevel)
    {
        var item = slot.GetItem();
        background.color = item.BackgroundColor;
        altColor.color = item.BackgroundColor;
        weaponColor.color = item.BackgroundColor;
        icon.sprite = item.Icon;
        nameText.text = item.ItemName;
        weaponName.text = item.WeaponName;

        if(item.CanGivePoint)
        {
            weaponName.transform.parent.gameObject.SetActive(false);
            item.MinPoint += (int)((item.MinPoint + currLevel) * (rewardPercentage/ 100));
            item.MaxPoint += (int)((item.MaxPoint + currLevel) * (rewardPercentage/ 100));
            item.currentPoint=Random.Range(item.MinPoint, item.MaxPoint);
            pointerText.text = "x"+item.currentPoint.ToString();
        }
        else
        {
            weaponName.transform.parent.gameObject.SetActive(true);
            weaponName.text = item.WeaponName;
            pointerText.text = item.RarityText;
        }
    }
    
}
