using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Linq;
using System;

public class SpinButton : MonoBehaviour
{
    [Header("----- Item Logic----")]
    [SerializeField] Item death;
    [SerializeField] GameObject deathScreen;
    [SerializeField] List<Item> items;
    [SerializeField] List<Slot> slots;


    [Header("----- Spin Logic----")]
    [SerializeField] RectTransform raycastPoint;
    [SerializeField] RectTransform spinningObject;
    [SerializeField] RectTransform slotObject;
    [SerializeField] RectTransform slotObjectIcon;
    [SerializeField] int rewardPercentage;

    [SerializeField] Transform spinningObjectPosition;
    [SerializeField] PopUpCardController popUpCardController;
    [SerializeField] Rewards Rewards;
    [SerializeField] iconSender iconSender;
    [SerializeField] levelCreator levelCreator;
    Button button;
    [SerializeField] bool withoutBomb;
    bool spinnStart;

    public float fadeTime = 1f;

    private void Start()
    {
        button=GetComponent<Button>();
    }

    public void Spinner()
    {
        if (!button.interactable) return;
        button.interactable = false;
        FillSpinnerObject();
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(spinningObject.DOBlendableLocalRotateBy(new Vector3(0, 0, UnityEngine.Random.Range(360, 1000)), 5f, RotateMode.FastBeyond360))
        .OnComplete(() =>
        {
            bool result = false;
            result = RaycastToSlot(mySequence);
            if (!result)
            {
                mySequence.Kill();
                Sequence mySequence2 = DOTween.Sequence();
                mySequence2.Append(spinningObject.DOBlendableLocalRotateBy(new Vector3(0, 0, 15), 0.2f, RotateMode.FastBeyond360))
                .OnComplete(() =>
                {
                    RaycastToSlot(mySequence2);
                    mySequence2.Kill();
                });
            }
            else
                mySequence.Kill();

        });
    }


    bool RaycastToSlot(Sequence mySequence)
    {
        var pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = raycastPoint.position;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        bool isHitSlot = false;
        for (int i = 0; i < results.Count; i++)
        {
            Slot slot;
            if (results[i].gameObject.TryGetComponent(out slot))
            {
                isHitSlot = true;
                //Debug.Log(results[i].gameObject);
                OpenObjects(slot);

            }
        }
        if (!isHitSlot) return false;
        else return true;
    }
    void OpenObjects(Slot slot)
    {
        Sequence mySequence = DOTween.Sequence();
        for (int i = 0; i < slots.Count; i++)
        {
            var temp = slots.IndexOf(slot);
            temp += 1 + i;

            if (slots.Count <= temp)
            {
                temp = temp - slots.Count;

            }
            //Destroy(slots[i].gameObject);
            Debug.Log(slots[temp].gameObject);
            var rectTransform = slots[temp].GetComponent<RectTransform>();
            rectTransform.rotation = spinningObjectPosition.rotation;
            mySequence.Append(rectTransform.DORotate(new Vector3(0, 90, 0), 0.2f, RotateMode.Fast));
            mySequence.OnComplete(() => {
                if (slot.GetItem().Equals(death))
                    deathScreen.SetActive(true);
                else PopObject(slot);
            });
        }

        //  mySequence.Append(.DOBlendableLocalRotateBy(new Vector3(0, 0, Random.Range(100, 1000)), 5f, RotateMode.FastBeyond360))
        //.OnComplete(() =>
        //{

        //});

        //}
    }
    void PopObject(Slot slot)
    {
        Sequence mySequence = DOTween.Sequence();
        popUpCardController.SetProperty(slot, rewardPercentage,levelCreator.currentLevel);
        //popUpCardController.SetProperty(slot); reward böyle
        mySequence.Append(slotObject.DOScale(1, 1f).SetEase(Ease.OutBack));
        mySequence.OnComplete(() =>
        {

            Sequence mySequence1 = DOTween.Sequence();
            var iconPos = Rewards.getPosofIcon(slot);
            var slotIcon = slot.GetItem().Icon;
            var animation = Instantiate(iconSender.gameObject, slotObjectIcon.transform);
            animation.GetComponent<iconSender>().SetIcon(slotIcon);
            // animation.transform.position = slotObjectIcon.rect.position;
            var rectAnim = animation.transform as RectTransform;
            mySequence.Kill();
            mySequence1.Append(rectAnim.DOMove(iconPos, 0.5f));
            mySequence1.OnComplete(() =>
            {
                Rewards.addItems(slot);
                PopCloseObject();
                mySequence1.Kill();
                Destroy(animation);
            }
            );
        });
    }
    void FillSpinnerObject()
    {
        var random = UnityEngine.Random.Range(0, slots.Count);
        for (int i = 0; i < slots.Count; i++)
        {
            var temp = random;
            temp += 1 + i;

            if (slots.Count <= temp)
            {
                temp -= slots.Count;

            }
           
            
            if (i == 0 && !withoutBomb)
            {
                
                slots[temp].SetItem(death);
            }
            else
            {
                var randomRarity = UnityEngine.Random.Range(0, 100);
                var selectedItem = items.Where(x => x.Rarity >= randomRarity).OrderBy(i => i.Rarity).FirstOrDefault();
                selectedItem = items.Where(x => x.Rarity == selectedItem.Rarity).OrderBy(i => Guid.NewGuid()).FirstOrDefault();

                slots[temp].SetItem(selectedItem);
            }
        }

    }
    void PopCloseObject()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(slotObject.DOScale(0, 1f).SetEase(Ease.OutBack));
        mySequence.OnComplete(() =>
        {
            refreshGame();
        });
    }

    public void refreshGame()
    {
        Sequence sequence = DOTween.Sequence();
        foreach (var slot in slots)
        {
            var slotReact = slot.transform as RectTransform;
            sequence.Append(slotReact.DORotate(new Vector3(0, 0, 0), 0.2f, RotateMode.Fast));
        }
        sequence.OnComplete(() =>{
            levelCreator.nextLevel();
        }); 
        

    }
    private void OnEnable()
    {
        foreach (var slot in slots)
        {
            var slotReact = slot.transform as RectTransform;
            slotReact.localRotation =new Quaternion(0,0, 0, 0);
        }
    }
}

