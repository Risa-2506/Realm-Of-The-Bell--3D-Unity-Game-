using UnityEngine;
using Cinemachine;

public class NoShootZone : MonoBehaviour
{
    private CinemachineImpulseSource impulseSource;
    private bool hasShaken = false;
    public float zoneRadius = 15f;
    private Transform player;
    private PlayerShoot playerShoot;
    //public float maxScale = 2.5f;
    //public float expandSpeed = 2f;

    //private float currentScale = 1f;

    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerShoot = player.GetComponentInChildren<PlayerShoot>();
        //transform.localScale = Vector3.one * currentScale;
        Debug.Log("Zone initialized");
    }

    void Update()
    {
        if (player == null || playerShoot == null) return;


        /*if (currentScale < maxScale)
        {
            currentScale += expandSpeed * Time.deltaTime;
            transform.localScale = new Vector3(currentScale, 1f, currentScale);
        }
        */
        float dynamicRadius = transform.localScale.x * 5f;
        //float distance = Vector3.Distance(transform.position, player.position);

        Vector3 flatPlayer = new Vector3(player.position.x, 0, player.position.z);
        Vector3 flatZone = new Vector3(transform.position.x, 0, transform.position.z);

        float distance = Vector3.Distance(flatPlayer, flatZone);
        Debug.Log("Distance: " + distance);

        if (distance <= zoneRadius)
        {
            if (!hasShaken)
            {
                impulseSource.GenerateImpulse();
                hasShaken = true;
            }

            playerShoot.canShoot = false;
        }
        else
        {
            hasShaken = false;
            playerShoot.canShoot = true;
        }
    }
}
