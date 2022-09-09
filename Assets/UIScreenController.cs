using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIScreenController : MonoBehaviour
{
    RectTransform MainUI;
    [SerializeField]RewardShower rewardShower;
    private void Start()
    {
        MainUI = GetComponent<RectTransform>();
       //MainUI.sizeDelta = new Vector2(MainUI.parent.GetComponent<RectTransform>().rect.width, MainUI.parent.GetComponent<RectTransform>().rect.height);
    }
    public void ExitQuestion()
    {
      
        MainUI.DOAnchorPosX(-Screen.width, 1f);
    }

    public void RewardScreen()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append( MainUI.DOAnchorPosY(Screen.height, 1f));
        sequence.OnComplete(() =>
        {
            rewardShower.showRewards();
        });
    }
    public void CancelExit()
    {
        MainUI.DOAnchorPosX(0, 1f);
    }

    public void gotoStart()
    {
        MainUI.DOAnchorPos(new Vector2(0, 0), 0f);
    }
}
