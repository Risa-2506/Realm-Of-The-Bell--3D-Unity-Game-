using UnityEngine;
using TMPro;

public class TempleDetailsUI : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI infoText;

    [TextArea(6, 15)]
    public string koreaTempleInfo;

    [TextArea(6, 15)]
    public string indiaTempleInfo;

    public void ShowKoreaTempleInfo()
    {
        infoText.text = koreaTempleInfo;
        infoPanel.SetActive(true);
    }

    public void ShowIndiaTempleInfo()
    {
        infoText.text = indiaTempleInfo;
        infoPanel.SetActive(true);
    }
}
