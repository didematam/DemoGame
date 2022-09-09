using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgain : MonoBehaviour
{
    Button button;
    [SerializeField] levelCreator levelCreator;
    [SerializeField] Rewards rewards;

  
    public void tryAgain()
    {
        levelCreator.refreshGame(); 
        foreach (Transform child in rewards.gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        rewards.rewardItems.Clear();
        transform.parent.gameObject.SetActive(false);
    }
}
