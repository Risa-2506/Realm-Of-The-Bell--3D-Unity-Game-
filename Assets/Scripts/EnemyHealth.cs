using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    private Animator animator;
    private bool isDead = false;
    NavMeshAgent agent;

void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        if (health <= 0)
        {
            Die();
            
        }
    }

    void Die()
    {
        isDead = true;

        // Stop AI movement first
        agent.isStopped = true;
        agent.ResetPath();   // 🔑 very important

        // Play death animation
        animator.SetTrigger("Die");

        // Disable agent & collider AFTER stopping
        agent.enabled = false;
        GetComponent<Collider>().enabled = false;

        GameManager.Instance.EnemyKilled();
        AudioManager.Instance.PlayEnemyDeath();

        // Destroy after animation
        Destroy(gameObject, 3f);

        

    }

}
