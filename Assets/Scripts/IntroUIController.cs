using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUIController : MonoBehaviour
{
    public GameObject storylinePanel;
    public GameObject controlsPanel;

    public void ShowStoryline()
    {
        storylinePanel.SetActive(true);
    }

    public void ShowControls()
    {
        controlsPanel.SetActive(true);
    }

    public void ClosePanels()
    {
        storylinePanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void ContinueToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

