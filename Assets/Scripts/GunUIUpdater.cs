using UnityEngine;
using TMPro;

public class GunUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI fastGunUnlockText;
    public TextMeshProUGUI fastGunSelectText;
    public TextMeshProUGUI starterGunSelectText;

    public void RefreshUI()
    {
        var gm = SimpleGunManager.instance;

        fastGunUnlockText.text = gm.isFastGunUnlocked ? "Unlocked" : "Unlock";

        fastGunSelectText.text = gm.selectedGun == 1 ? "Selected" : "Select";

        starterGunSelectText.text = gm.selectedGun == 0 ? "Selected" : "Select";
    }

    void Start()
    {
        RefreshUI();
    }
}
