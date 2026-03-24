using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public bool useGestureMode;
    public void StartGame()
    {
        if (GestureManager.Instance != null)
        {
            GestureManager.Instance.useGestures = useGestureMode;
        }

        SceneManager.LoadScene("GameScene");
    }
}
