using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random; //this solved a small error down below. 

public class Sooter : MonoBehaviour
{
    [Header("Base Variables")]

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float BaseFireRate = 0.2f;
    [HideInInspector] public bool isFiring;
    Coroutine FireCo;

    [Header("AI Variables")] 
    [SerializeField] float MinFirerate = 0.2f;
    [SerializeField] float FireRateVariance = 0f;
    [SerializeField] bool UseAI;


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
        else if (!isFiring && FireCo != null)
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
            projectileRb.linearVelocity = transform.up * projectileSpeed;

            Destroy(projectile, projectileLifeTime);

            float waitTime = Random.Range(BaseFireRate - FireRateVariance, BaseFireRate + FireRateVariance);
            waitTime = Mathf.Clamp(waitTime, MinFirerate, float.MaxValue);

            yield return new WaitForSeconds(waitTime);
        }
    }
}
