using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class reviaveButton : MonoBehaviour
{
    Button button;
    [SerializeField] Loot loot;
    [SerializeField] int revivePoint;
    [SerializeField] Sprite coinIcon;
    [SerializeField] SpinButton bronze;
    [SerializeField] SpinButton silver;
    [SerializeField] SpinButton gold;


    private void OnValidate()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(reviave);

    }
    void reviave()
    {
        if((loot.lootItems.Where(x=> x.lootIcon.sprite == coinIcon).First().lootPoint) >= revivePoint)
        {
            transform.parent.gameObject.SetActive(false);
            loot.lootItems.Where(x => x.lootIcon.sprite == coinIcon).First().setLootPoit(revivePoint);
            bronze.refreshGame();
            silver.refreshGame();
            gold.refreshGame();
        }

    }
}
