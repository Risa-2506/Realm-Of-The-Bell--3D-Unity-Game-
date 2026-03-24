using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    //public AudioSource runSource;
    public AudioSource shootSource;
    public AudioSource sfxSource;   // potion + enemy
    //public AudioSource musicSource;

    [Header("Audio Clips")]
    //public AudioClip runClip;
    public AudioClip shootClip;
    public AudioClip potionClip;
    public AudioClip enemyDeathClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // 🏃 RUN
    /*public void PlayRun()
    {
        if (!runSource.isPlaying)
            runSource.Play();
    }

    public void StopRun()
    {
        if (runSource.isPlaying)
            runSource.Stop();
    }*/

    // 🔫 SHOOT
    public void PlayShoot()
    {
        shootSource.PlayOneShot(shootClip);
    }

    // 🧪 POTION
    public void PlayPotion()
    {
        sfxSource.PlayOneShot(potionClip);
    }

    // 💀 ENEMY
    public void PlayEnemyDeath()
    {
        sfxSource.PlayOneShot(enemyDeathClip);
    }
}

