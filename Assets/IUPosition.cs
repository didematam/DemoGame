using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUPosition : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] bool left;
    [SerializeField] bool right;
    [SerializeField] bool bottom;
    [SerializeField] bool top;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        if (left)
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x - Screen.width, rectTransform.localPosition.y);
        if (right)
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x + Screen.width, rectTransform.localPosition.y);
        if (top)
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x, rectTransform.localPosition.y + Screen.height);
        if (bottom)
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x, rectTransform.localPosition.y - Screen.height);
    }
}
