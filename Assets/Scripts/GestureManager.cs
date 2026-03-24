using UnityEngine;
using UnityEngine.SceneManagement;




    public class GestureManager : MonoBehaviour
    {
        public static GestureManager Instance;

        [Header("Mode Settings")]
        public bool useGestures = false;   // True = Gesture mode
        public bool isFist = false;        // Set by hand tracking script

        [Header("Gesture Scene")]
        public string gestureSceneName = "Hand Landmark Detection";

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // When GameScene loads → load hand tracking if gesture mode is ON
            if (scene.name == "GameScene" && useGestures)
            {
                SceneManager.LoadScene(gestureSceneName, LoadSceneMode.Additive);
            }
        }
    }
