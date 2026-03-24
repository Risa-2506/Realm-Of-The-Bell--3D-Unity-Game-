using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI TotalEnemiesText;
    public TextMeshProUGUI enemieskilledText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI potionRunText;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        int run = PotionManager.instance.potionsThisRun;
        potionRunText.text = "Potions: " + run;
    }

    public void UpdateTimer(float time)
    {
        timerText.text = "TIME: " + Mathf.CeilToInt(time);
    }

    public void TotalEnemyCount(int count)
    {
        TotalEnemiesText.text = "Total Enemies: " + count;
    }

    public void UpdateEnemyCount(int count)
    {
        enemieskilledText.text = "Enemies Killed: " + count;
    }

    public void ShowResult(string message)
    {
        resultText.text = message;
    }
}

