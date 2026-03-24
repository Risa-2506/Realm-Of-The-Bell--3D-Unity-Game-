
//using Mediapipe.Unity.Sample.HandLandmarkDetection;
//using Mediapipe.Tasks.Vision.HandLandmarker;

//public class FistDetector : MonoBehaviour
//{
//private HandLandmarkerRunner runner;

// Anti-flicker stability
//private int fistFrames = 0;
// private const int requiredFrames = 4;   // Increase = more stable, decrease = more responsive

//void Update()
/*{
    // Connect to runner dynamically (safe for additive scenes)
    if (runner == null)
    {
        runner = FindObjectOfType<HandLandmarkerRunner>();

        if (runner != null)
        {
            runner.OnHandLandmarksReceived += OnHandLandmarks;
            Debug.Log("FistDetector connected to runner");
        }
    }
}

private void OnDestroy()
{
    if (runner != null)
    {
        runner.OnHandLandmarksReceived -= OnHandLandmarks;
    }
}

private void OnHandLandmarks(HandLandmarkerResult result, Mediapipe.Image image, long timestamp)
{
    if (GestureManager.Instance == null)
        return;

    if (result.handLandmarks == null || result.handLandmarks.Count == 0)
    {
        fistFrames = 0;
        GestureManager.Instance.isFist = false;
        return;
    }

    var landmarks = result.handLandmarks[0].landmarks;

    // Finger curl detection (tip vs mid joint)
    bool indexBent = landmarks[8].y > landmarks[6].y;
    bool middleBent = landmarks[12].y > landmarks[10].y;
    bool ringBent = landmarks[16].y > landmarks[14].y;
    bool pinkyBent = landmarks[20].y > landmarks[18].y;

    // Thumb curl detection (sideways movement)
    bool thumbBent = Mathf.Abs(landmarks[4].x - landmarks[2].x) < 0.05f;

    bool fingersClosed = indexBent && middleBent && ringBent && pinkyBent && thumbBent;

    // Anti-flicker stability logic
    if (fingersClosed)
    {
        fistFrames++;
    }
    else
    {
        fistFrames = 0;
    }

    bool finalFist = fistFrames >= requiredFrames;

    GestureManager.Instance.isFist = finalFist;

    if (finalFist)
        Debug.Log("FIST TRUE");
}
}*/
/*using UnityEngine;
using Mediapipe.Unity.Sample.HandLandmarkDetection;
using Mediapipe.Tasks.Vision.HandLandmarker;

public class FistDetector : MonoBehaviour
{
    private HandLandmarkerRunner runner;

    // Anti-flicker stability
    private int fistFrames = 0;
    private const int requiredFrames = 4;   // Increase = more stable, decrease = more responsive

    void Update()
    {
        // Connect to runner dynamically (safe for additive scenes)
        if (runner == null)
        {
            runner = FindObjectOfType<HandLandmarkerRunner>();

            if (runner != null)
            {
                runner.OnHandLandmarksReceived += OnHandLandmarks;
                Debug.Log("FistDetector connected to runner");
            }
        }
    }

    private void OnDestroy()
    {
        if (runner != null)
        {
            runner.OnHandLandmarksReceived -= OnHandLandmarks;
        }
    }

    private void OnHandLandmarks(HandLandmarkerResult result, Mediapipe.Image image, long timestamp)
    {
        if (GestureManager.Instance == null)
            return;

        if (result.handLandmarks == null || result.handLandmarks.Count == 0)
        {
            fistFrames = 0;
            GestureManager.Instance.isFist = false;
            return;
        }

        var landmarks = result.handLandmarks[0].landmarks;

        // Finger curl detection (tip vs mid joint)
        bool indexBent = landmarks[8].y > landmarks[6].y;
        bool middleBent = landmarks[12].y > landmarks[10].y;
        bool ringBent = landmarks[16].y > landmarks[14].y;
        bool pinkyBent = landmarks[20].y > landmarks[18].y;

        // Thumb curl detection (sideways movement)
        bool thumbBent = Mathf.Abs(landmarks[4].x - landmarks[2].x) < 0.05f;

        bool fingersClosed = indexBent && middleBent && ringBent && pinkyBent && thumbBent;

        // Anti-flicker stability logic
        if (fingersClosed)
        {
            fistFrames++;
        }
        else
        {
            fistFrames = 0;
        }

        bool finalFist = fistFrames >= requiredFrames;

        GestureManager.Instance.isFist = finalFist;

        if (finalFist)
            Debug.Log("FIST TRUE");
    }
}*/
using UnityEngine;
using Mediapipe.Unity.Sample.HandLandmarkDetection;
using Mediapipe.Tasks.Vision.HandLandmarker;
using System.Collections.Generic;

public class FistDetector : MonoBehaviour
{
    private HandLandmarkerRunner runner;

    void Start()
    {
        runner = FindObjectOfType<HandLandmarkerRunner>();

        if (runner != null)
        {
            runner.OnHandLandmarksUpdated += OnHandLandmarks;
            Debug.Log("Connected to runner");
        }
    }

    private void OnDestroy()
    {
        if (runner != null)
        {
            runner.OnHandLandmarksUpdated -= OnHandLandmarks;
        }
    }

    void OnHandLandmarks(HandLandmarkerResult result)
    {
        if (result.handLandmarks == null || result.handLandmarks.Count == 0)
        {
            GestureManager.Instance.isFist = false;
            return;
        }

        var landmarks = result.handLandmarks[0].landmarks;

        bool indexBent = landmarks[8].y > landmarks[6].y;
        bool middleBent = landmarks[12].y > landmarks[10].y;
        bool ringBent = landmarks[16].y > landmarks[14].y;
        bool pinkyBent = landmarks[20].y > landmarks[18].y;

        bool thumbBent = Mathf.Abs(landmarks[4].x - landmarks[2].x) < 0.05f;

        bool isFist = indexBent && middleBent && ringBent && pinkyBent && thumbBent;


        GestureManager.Instance.isFist = isFist;

        Debug.Log("Fist: " + isFist);
    }
}
