using UnityEngine;
using Cinemachine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.4f;
    public float shakeMagnitude = 0.2f;

    private CinemachineVirtualCamera vcam;
    private CinemachineTransposer transposer;
    private Vector3 originalOffset;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
        originalOffset = transposer.m_FollowOffset;
    }

    public void TriggerShake()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector3 randomOffset = originalOffset +
                new Vector3(
                    Random.Range(-1f, 1f) * shakeMagnitude,
                    Random.Range(-1f, 1f) * shakeMagnitude,
                    0);

            transposer.m_FollowOffset = randomOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }

        transposer.m_FollowOffset = originalOffset;
    }
}
