using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;

    bool isDead = false;
    float baseSpeed;
    public static float globalSpeedMultiplier = 1f;

    public float minSpeed = 4f;
    public float maxSpeed = 7f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // find player automatically
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
        //baseSpeed = Random.Range(minSpeed, maxSpeed);
        // random speed per enemy
        agent.speed = Random.Range(minSpeed, maxSpeed);
        
        // optional tuning
        agent.acceleration = 20f;
        agent.angularSpeed = 720f;
        agent.stoppingDistance = 1.5f;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.EnemyTouchedPlayer();
        }
    }

    void Update()
    {
        if (isDead) return;
        if (agent == null) return;
        if (!agent.enabled) return;
        if (!agent.isOnNavMesh) return;
        //agent.speed = baseSpeed * globalSpeedMultiplier;
        // ALWAYS move toward player
        agent.SetDestination(player.position);
    }
}
