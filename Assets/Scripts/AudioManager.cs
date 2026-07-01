using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0, 1)] float ShootingVolume;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0, 1)] float DamageVolume;

    static AudioManager instance;

    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        // int instanceCount = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        // if(instanceCount > 1)

        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingSFX()
    {
        if (shootingClip != null)
        {
            PlayAudioClip(shootingClip, ShootingVolume);
        }
    }
    public void PlayDamageSFX()
    {
        if (damageClip != null)
        {
            PlayAudioClip(damageClip, DamageVolume);
        }
    }

    private void PlayAudioClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
