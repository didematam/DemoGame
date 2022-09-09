using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootItem : MonoBehaviour
{
    public Image lootIcon;
    public TextMeshProUGUI lootText;
    public int lootPoint;

    public void setLootPoit(int point)
    {
        lootPoint -= point;
        lootText.text = lootPoint.ToString();
    }
}
