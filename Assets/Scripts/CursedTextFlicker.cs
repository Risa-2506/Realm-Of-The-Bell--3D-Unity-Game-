using UnityEngine;
using TMPro;

public class CursedTextFlicker : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float flickerSpeed = 6f;
    public bool isGameOver = false;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (isGameOver)
        {
            text.alpha = 0f;   // instantly hide text
            return;
        }
        // Soft random alpha flicker
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f);
        float alpha = Mathf.Lerp(0.7f, 1f, noise);
        text.alpha = alpha;

        Vector3 pos = transform.localPosition;
        pos.y = Mathf.Sin(Time.time * 1.5f) * 5f;
        transform.localPosition = pos;
    }
}
