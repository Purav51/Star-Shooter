using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision happend with a damage dealer
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            // Reduce Health
            TakeDamage(damageDealer.GetDamage());
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
}
