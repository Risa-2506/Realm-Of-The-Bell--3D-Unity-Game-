using UnityEngine;

public class SimpleGunManager : MonoBehaviour
{
    public static SimpleGunManager instance;

    public bool isFastGunUnlocked;
    public int selectedGun;
    // 0 = StarterGun, 1 = FastGun

    public int fastGunCost = 30;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        LoadData();
    }

    void LoadData()
    {
        isFastGunUnlocked = PlayerPrefs.GetInt("FastGunUnlocked", 0) == 1;
        selectedGun = PlayerPrefs.GetInt("SelectedGun", 0);
    }

    public void UnlockFastGun()
    {
        if (isFastGunUnlocked)
        {
            Debug.Log("Fast gun already unlocked");
            return;
        }

        int totalPotions = PlayerPrefs.GetInt("TotalPotions", 0);

        if (totalPotions >= fastGunCost)
        {
            totalPotions -= fastGunCost;
            PlayerPrefs.SetInt("TotalPotions", totalPotions);

            isFastGunUnlocked = true;
            PlayerPrefs.SetInt("FastGunUnlocked", 1);

            Debug.Log("Fast gun unlocked!");
        }
        else
        {
            Debug.Log("Not enough potions");
        }
    }


    public void SelectStarterGun()
    {
        selectedGun = 0;
        PlayerPrefs.SetInt("SelectedGun", selectedGun);
        Debug.Log("Starter gun selected");
    }

    public void SelectFastGun()
    {
        if (!isFastGunUnlocked)
        {
            Debug.Log("Fast gun locked");
            return;
        }

        selectedGun = 1;
        PlayerPrefs.SetInt("SelectedGun", selectedGun);
        Debug.Log("Fast gun selected");
    }
}
