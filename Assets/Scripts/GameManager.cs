using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    public float timePerEnemy = 12f;

    public int totalEnemies;
    public int enemiesKilled;
    public float timer;
    private bool gameOver;
    [SerializeField] private GameObject cursedTextObject;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (gameOver) return;

        timer -= Time.deltaTime;
        UIManager.Instance.UpdateTimer(timer);
        


        if (timer <= 0f)
        {
            EnemyWins("Time Over");
        }
    }

    // Called by EnemySpawner
    public void RegisterEnemy()
    {
        totalEnemies++;
        UIManager.Instance.TotalEnemyCount(totalEnemies);

    }

    // Called once after spawning
    public void StartGameTimer()
    {
        timer = totalEnemies * timePerEnemy;
        Debug.Log("Game Time: " + timer);
    }

    // Called when enemy dies
    public void EnemyKilled()
    {
        enemiesKilled++;
        UIManager.Instance.UpdateEnemyCount(enemiesKilled);

        if (enemiesKilled >= totalEnemies)
        {
            PlayerWins();
        }
    }

    // Called when enemy touches player
    public void EnemyTouchedPlayer()
    {
        EnemyWins("Enemy touched player");
    }

    void PlayerWins()
    {
        gameOver = true;
        Debug.Log("PLAYER WINS");
        Time.timeScale = 0f;
        PotionManager.instance.SavePotions();

        UIManager.Instance.ShowResult("YOU WIN!");
        EndGame();

    }

    void EnemyWins(string reason)
    {
        gameOver = true;

        if (cursedTextObject != null)
            cursedTextObject.SetActive(false);  

        Debug.Log("ENEMY WINS: " + reason);
        Time.timeScale = 0f;
        PotionManager.instance.SavePotions();

        UIManager.Instance.ShowResult("YOU LOSE!" + reason);
        EndGame();

    }
    void EndGame()
    {
        StartCoroutine(LoadMenuAfterDelay());
    }
    IEnumerator LoadMenuAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f; // VERY IMPORTANT
        SceneManager.LoadScene("MenuScene");
    }

}
