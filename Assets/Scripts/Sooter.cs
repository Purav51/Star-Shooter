using System.Collections;
using UnityEngine;

public class Sooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float projectileFireRate = 0.2f;

    Coroutine FireCo;
    public bool isFiring;

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && FireCo == null)
        {
            // Fire projectiles
            FireCo = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && FireCo != null)
        {
            // Stop firing projectiles
            StopCoroutine(FireCo);
            FireCo = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity); //instantiate projectile in this specific position and without changing rotation 
            
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.linearVelocityY = projectileSpeed;

            Destroy(projectile, projectileLifeTime);



            yield return new WaitForSeconds(projectileFireRate);
        }
    }
}
