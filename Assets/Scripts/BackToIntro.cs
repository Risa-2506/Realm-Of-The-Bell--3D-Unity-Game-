using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToIntro : MonoBehaviour
{
    public void GoToIntro()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
