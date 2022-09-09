using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;

public class levelCreator : MonoBehaviour
{
    public int maxLevel;
    [HideInInspector]public int currentLevel=1;
    public GameObject LevelPrefeb; 
    public GameObject LevelShower; 
    public List<GameObject> levels;

    public Sprite normalZone;
    public Sprite safeZone;
    public Sprite superZone;
  
    public GameObject bronzeSpinner;
    public GameObject silverSpinner;
    public GameObject goldSpinner;

    public Button bronzeSpinnerButton;
    public Button silverSpinnerButton;
    public Button goldSpinnerButton;


    void Start()
    {

        currentLevel = 1;
        for (int level = 1; level < maxLevel; level++)
        {
            var levelPrefeb = Instantiate(LevelPrefeb, transform);
            levels.Add(levelPrefeb);
            var rectTransform = transform.parent as RectTransform;
            var levelPrefebTransform = levelPrefeb.transform as RectTransform;
            levelPrefebTransform.sizeDelta = new Vector2(rectTransform.rect.width,100);
            levelPrefebTransform.position = transform.position;
            levelPrefebTransform.position -= Vector3.up*(110*level);
            if (level == 1)
            {
                levelPrefeb.GetComponent<Image>().sprite = safeZone;
            }
            else if (level % 30 == 0)
            { 
                levelPrefeb.GetComponent<Image>().sprite = superZone;
            }
            else if(level % 5 == 0)
            {
                levelPrefeb.GetComponent<Image>().sprite = safeZone;
            }
            else
            {
                levelPrefeb.GetComponent<Image>().sprite = normalZone;
            }
            levelPrefeb.GetComponentInChildren<TextMeshProUGUI>().text = level.ToString();

        }
        gotoLevel(0);


    }
    public void refreshGame()
    {
        currentLevel = 0;
        nextLevel();
    }
    public void nextLevel()
    {
        gotoLevel(currentLevel++);
    }
    void gotoLevel(int level)
    {
        bronzeSpinnerButton.interactable = false;
        silverSpinnerButton.interactable = false;
        goldSpinnerButton.interactable = false;

        Sequence sequence = DOTween.Sequence();
       var offset = LevelShower.transform.position - levels[level].transform.position;
        sequence.Append(transform.DOMove(transform.position + offset,1));
        sequence.OnComplete(() =>
        {
            if(levels[level].GetComponent<Image>().sprite == normalZone)
            {
                bronzeSpinnerButton.interactable = true;
                bronzeSpinner.SetActive(true);
                silverSpinner.SetActive(false);
                goldSpinner.SetActive(false);
            }
            else if (levels[level].GetComponent<Image>().sprite == safeZone)
            {
                silverSpinnerButton.interactable = true;
                silverSpinner.SetActive(true);
                bronzeSpinner.SetActive(false);
                goldSpinner.SetActive(false);
            }
            else if (levels[level].GetComponent<Image>().sprite == superZone)
            {
                goldSpinnerButton.interactable = true;
                goldSpinner.SetActive(true);
                bronzeSpinner.SetActive(false);
                silverSpinner.SetActive(false);
            }
        });


    }
}
