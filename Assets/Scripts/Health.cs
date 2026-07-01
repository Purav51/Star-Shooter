using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int ScoreValue = 50;
    [SerializeField] int health;
    [SerializeField] ParticleSystem hitParticles;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = FindFirstObjectByType<AudioManager>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        levelManager = FindFirstObjectByType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision happend with a damage dealer
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            // Reduce Health
            TakeDamage(damageDealer.GetDamage());
            PlayerHitParticles();
            damageDealer.Hit();
            audioManager.PlayDamageSFX();
            if (applyCameraShake)
            {
                cameraShake.PlayShakeEffect();
            }
        }
    }
    void TakeDamage(int takenDamage)
    {
        health -= takenDamage;
        if (health <= 0)
        {
            Die();
        }
    }
    void PlayerHitParticles()
    {
        if (hitParticles != null)
        {
            ParticleSystem particles = Instantiate(hitParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }
    public int GetHealth()
    {
        return health;
    }
    void Die()
    {
        if (isPlayer)
        {
            levelManager.LoadGameOver();
        }
        else
        {
            scoreKeeper.ModifyScore(ScoreValue);
        }
        Destroy(gameObject);
    }
}
