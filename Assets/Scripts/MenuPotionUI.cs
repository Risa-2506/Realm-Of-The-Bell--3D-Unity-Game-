using UnityEngine;
using TMPro;

public class MenuPotionUI : MonoBehaviour
{
    public TextMeshProUGUI totalPotionsText;

    void Update()
    {
        int total = PlayerPrefs.GetInt("TotalPotions", 0);
        totalPotionsText.text = "Total Potions: " + total;
    }
}
