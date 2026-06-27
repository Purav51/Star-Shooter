using System.Collections;
using UnityEngine;

public class Sooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float projectileFireRate = 0.2f;
    [SerializeField] bool UseAI;

    [HideInInspector] public bool isFiring;
    Coroutine FireCo;

    void Start()
    {
        if (UseAI)
        {
            isFiring = true;
        }
    }
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

            projectile.transform.rotation = transform.rotation;
            
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.linearVelocity = transform.up *projectileSpeed;

            Destroy(projectile, projectileLifeTime);



            yield return new WaitForSeconds(projectileFireRate);
        }
    }
}
