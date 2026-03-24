using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy")]
    public GameObject enemyPrefab;

    [Header("Spawn Points Parent")]
    public Transform spawnPointsParent;

    [Header("Spawn Settings")]
    public int minEnemies = 5;
    public int maxEnemies = 10;
   // public static float spawnMultiplier = 1f;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        int enemyCount = Random.Range(minEnemies, maxEnemies + 1);


        for (int i = 0; i < enemyCount; i++)
        {
            Transform spawnPoint = GetRandomSpawnPoint();
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            GameManager.Instance.RegisterEnemy();
        }
        GameManager.Instance.StartGameTimer();

    }

    Transform GetRandomSpawnPoint()
    {
        int childCount = spawnPointsParent.childCount;
        int index = Random.Range(0, childCount);
        return spawnPointsParent.GetChild(index);
    }
}
