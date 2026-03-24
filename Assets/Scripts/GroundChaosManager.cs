using UnityEngine;
using System.Collections;

public class GroundChaosManager : MonoBehaviour
{
    public GameObject zonePrefab;
    public Transform player;

    public float eventInterval = 25f;
    public float zoneDuration = 6f;

    void Start()
    {
        StartCoroutine(EventLoop());
    }

    IEnumerator EventLoop()
    {
        while (true)
        {
            float randomDelay = Random.Range(15f, 35f);
            yield return new WaitForSeconds(randomDelay);

            SpawnZoneUnderPlayer();

        }
    }

    void SpawnZoneUnderPlayer()
    {
        Vector3 spawnPos = player.position;
        spawnPos.y = 0.05f; // slightly above ground

        GameObject zone = Instantiate(zonePrefab, spawnPos, Quaternion.identity);

        float randomDuration = Random.Range(5f, 9f);
        StartCoroutine(DestroyAfterTime(zone, randomDuration));
    }

    IEnumerator DestroyAfterTime(GameObject zone, float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(zone);
    }
}
