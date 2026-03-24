using UnityEngine;
using UnityEngine.UI;

public class GunMenuUI : MonoBehaviour
{
    public Button unlockFastGunButton;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        bool unlocked = PlayerPrefs.GetInt("FastGunUnlocked", 0) == 1;

        if (unlocked)
        {
            unlockFastGunButton.interactable = false;
        }
        else
        {
            unlockFastGunButton.interactable = true;
        }
    }
}
