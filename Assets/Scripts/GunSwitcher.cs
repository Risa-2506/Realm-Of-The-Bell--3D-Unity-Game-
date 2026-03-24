using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public GameObject starterGun;
    public GameObject fastGun;

    void Start()
    {
        int gun = SimpleGunManager.instance.selectedGun;

        starterGun.SetActive(false);
        fastGun.SetActive(false);

        if (gun == 0)
        {
            starterGun.SetActive(true);
        }
        else if (gun == 1)
        {
            fastGun.SetActive(true);
        }
    }
}

