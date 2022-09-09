using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iconSender : MonoBehaviour
{
    [SerializeField] Image up,down,left,right;
    
    public void SetIcon(Sprite sprite)
    {
        up.sprite = sprite;
        down.sprite = sprite;
        left.sprite = sprite;
        right.sprite = sprite;
    }

   
}
