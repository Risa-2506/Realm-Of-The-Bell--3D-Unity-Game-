using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public static PotionManager instance;

    public int potionsThisRun;
    public int totalPotions;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        LoadTotalPotions();
    }

    public void AddPotion(int amount)
    {
        potionsThisRun += amount;
        Debug.Log("Potion collected! This run: " + potionsThisRun);
    }

    public void SavePotions()
    {
        totalPotions += potionsThisRun;
        Debug.Log("Saving potions...");
        Debug.Log("Total Potions: " + totalPotions);
        PlayerPrefs.SetInt("TotalPotions", totalPotions);
        PlayerPrefs.Save();

        potionsThisRun = 0;
    }

    void LoadTotalPotions()
    {
        totalPotions = PlayerPrefs.GetInt("TotalPotions", 0);
    }
}

