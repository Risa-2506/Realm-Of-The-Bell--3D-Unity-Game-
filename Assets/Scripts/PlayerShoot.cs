using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject shootButton;
    public CanvasGroup cursedGroup;
    private Vignette vignette;
    public int damage = 100;
    public float range = 10f;
    public Camera cam;
    public bool canShoot = true;
    [SerializeField] private ParticleSystem pistolVFX;
    [SerializeField] private ParticleSystem heavyVFX;

    private bool wasFistLastFrame = false;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;

        Volume volume = FindObjectOfType<Volume>();

        if (volume != null)
        {
            volume.profile.TryGet(out vignette);
        }

        if (vignette != null)
        {
            vignette.intensity.value = 0f;
        }
    }

    void Update()
    {
        
        /*if (!IsInsideZone() && Input.GetMouseButtonDown(0))
        {
            Shoot();
            AudioManager.Instance.PlayShoot();
        }*/

        /*bool gestureMode = GestureManager.Instance != null &&
                   GestureManager.Instance.useGestures;

        Debug.Log("GestureMode: " + gestureMode);

        bool normalInput = Input.GetMouseButtonDown(0);

        bool gestureInput = GestureManager.Instance != null &&
                            GestureManager.Instance.isFist;

        bool shouldShoot = false;

        if (gestureMode)
        {
            if (GestureManager.Instance != null)
            {
                Debug.Log("Fist: " + GestureManager.Instance.isFist);
                bool isFistNow = GestureManager.Instance.isFist;

                // Detect fist JUST pressed (like button down)
                if (isFistNow && !wasFistLastFrame)
                {
                    shouldShoot = true;
                }

               // wasFistLastFrame = isFistNow;
            }
        }
        else
        {
            shouldShoot = normalInput;
        }

        if (!IsInsideZone() && shouldShoot)
        {
            Shoot();
            AudioManager.Instance.PlayShoot();
        }*/

        bool gestureMode = GestureManager.Instance != null &&
                   GestureManager.Instance.useGestures;

        if (!gestureMode)
        {
            if (EventSystem.current != null &&
               EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
        }
        if (shootButton != null)
        {
            shootButton.SetActive(!gestureMode);
        }
        bool shouldShoot = false;

        if (gestureMode)
        {
            if (GestureManager.Instance != null)
            {
                bool isFistNow = GestureManager.Instance.isFist;

                if (isFistNow && !wasFistLastFrame)
                {
                    shouldShoot = true;
                }

                wasFistLastFrame = isFistNow;
            }
        }
        else
        {
            #if UNITY_EDITOR || UNITY_STANDALONE
                if (Input.GetMouseButtonDown(0))
                    shouldShoot = true;
            #endif
        }

        Debug.Log("GestureMode: " + gestureMode);
        Debug.Log("Fist: " + (GestureManager.Instance != null ? GestureManager.Instance.isFist : false));
        Debug.Log("ShouldShoot: " + shouldShoot);
        Debug.Log("InsideZone: " + IsInsideZone());


        if (!IsInsideZone() && shouldShoot)
        {
            Shoot();
            AudioManager.Instance.PlayShoot();
        }

        bool inside = IsInsideZone();

        float targetAlpha = inside ? 1f : 0f;
        float targetVignette = inside ? 0.4f : 0f;

        if (cursedGroup != null)
        {
            cursedGroup.alpha = Mathf.Lerp(
                cursedGroup.alpha,
                targetAlpha,
                Time.deltaTime * 3f
            );
        }

        if (vignette != null)
        {
            vignette.intensity.value = Mathf.Lerp(
                vignette.intensity.value,
                targetVignette,
                Time.deltaTime * 3f
            );
        }
    }

    void Shoot()
    {
        //if (!canShoot) return;

        if (IsInsideZone())
            return;

        if (pistolVFX.gameObject.activeInHierarchy)
        {
            pistolVFX.Play();
        }
        else if (heavyVFX.gameObject.activeInHierarchy)
        {
            heavyVFX.Play();
        }

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            
            Debug.Log("Hit: " + hit.collider.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                EnemyHealth enemy = hit.collider.GetComponentInParent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
        
        
    }
    public void ShootFromButton()
    {
        if (IsInsideZone()) return;

        // If gesture mode is ON, button should NOT shoot
        if (GestureManager.Instance != null &&
            GestureManager.Instance.useGestures)
        {
            return;
        }

        Shoot();
        AudioManager.Instance.PlayShoot();
    }

    bool IsInsideZone()
    {
        NoShootZone zone = FindObjectOfType<NoShootZone>();
        if (zone == null) return false;

        Transform playerRoot = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.DrawLine(flatZone, flatZone + Vector3.forward * radius, Color.red);
        Vector3 flatPlayer = new Vector3(playerRoot.position.x, 0, playerRoot.position.z);
        Vector3 flatZone = new Vector3(zone.transform.position.x, 0, zone.transform.position.z);

        float radius = zone.transform.localScale.x * 5f;
        float distance = Vector3.Distance(flatPlayer, flatZone);

        return distance <= radius;
    }

    

}
