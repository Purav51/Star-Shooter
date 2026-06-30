using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float ShakeDuration = 0.5f;
    [SerializeField] float ShakeMagnitude = 0.5f;

    Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;
    }

    public void PlayShakeEffect()
    {
        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        float timeElapsed = 0f;
        while (timeElapsed < ShakeDuration)
        {
            transform.position = initialPos + (Vector3)Random.insideUnitCircle * ShakeMagnitude; //(Vector3)Random.insideUnitCircle is a casted variable. 
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPos;

    }
}
