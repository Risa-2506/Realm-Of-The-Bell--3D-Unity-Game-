using UnityEngine;
using System.Collections;

public class FogController : MonoBehaviour
{
    public float fogDuration = 8f;
    public float intervalTime = 20f;
    public float fogDensity = 0.03f;

    void Start()
    {
        RenderSettings.fogDensity = 0f; // start invisible
        StartCoroutine(FogRoutine());
    }

    IEnumerator FogRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);

            // Enable fog (increase density)
            RenderSettings.fogDensity = fogDensity;

            yield return new WaitForSeconds(fogDuration);

            // Disable fog (back to invisible)
            RenderSettings.fogDensity = 0f;
        }
    }
}
