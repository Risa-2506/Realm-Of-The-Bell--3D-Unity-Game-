using UnityEngine;

public class PotionCollect : MonoBehaviour
{
    public int potionValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayPotion();
            PotionManager.instance.AddPotion(potionValue);
            Destroy(gameObject);
        }
    }
}

