using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0,1)] float ShootingVolume;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0,1)] float DamageVolume;

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
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
