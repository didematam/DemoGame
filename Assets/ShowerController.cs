using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowerController : MonoBehaviour
{
    public TextMeshProUGUI ItemName;
    public Image Icon;
    public TextMeshProUGUI currentPoint;
    public void fillItem(Slot slot)
    {
        ItemName.text = slot.GetItem().ItemName;
        currentPoint.text = slot.GetItem().currentPoint.ToString();
        Icon.sprite = slot.GetItem().Icon;
    }

}
