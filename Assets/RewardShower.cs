using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class RewardShower : MonoBehaviour
{
   [SerializeField] Loot loot;
   [SerializeField] Rewards Rewards;
    [SerializeField] GameObject rewardPrefab;
   [SerializeField] GameObject pivot;
   [SerializeField] UIScreenController uIScreenController;
   [SerializeField] levelCreator levelCreator;

    void restartGame()
    {
        levelCreator.refreshGame();
        foreach (Transform child in Rewards.gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        Rewards.rewardItems.Clear();
    }
    public  void showRewards()
    {
            Sequence mySequence = DOTween.Sequence();
        foreach (var reward in Rewards.rewardItems)
        {
            loot.addItems(reward.rewardSlot);
            var rewardshower = Instantiate(rewardPrefab, transform);
            rewardshower.GetComponent<ShowerController>().fillItem(reward.rewardSlot);
            var rewardshowerTrans = rewardshower.transform as RectTransform;
            mySequence.Append(rewardshowerTrans.DOMove((pivot.transform as RectTransform).position, 3f).OnComplete(() => Destroy(rewardshowerTrans.gameObject)));
            mySequence.Join(rewardshowerTrans.DOScale(1, 2f));
            mySequence.OnComplete(() => {
                restartGame(); Invoke("gotoMainPage", 1);
            });
        }
    }
    void gotoMainPage()
    {
        uIScreenController.gotoStart(); 
    }
}
