using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitParticles;

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
        }
    }
    void TakeDamage(int takenDamage)
    {
        health -= takenDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
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
}
