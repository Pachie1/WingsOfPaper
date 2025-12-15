using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip healClip;
    [SerializeField] private AudioClip shieldClip;

    [SerializeField] private float minPitch = 0.95f;
    [SerializeField] private float maxPitch = 1.05f;

    private void Reset()
    {
        if (sfxSource == null)
            sfxSource = GetComponent<AudioSource>();
    }

    private void PlayClip(AudioClip clip)
    {
        if (sfxSource == null || clip == null) return;

        sfxSource.pitch = Random.Range(minPitch, maxPitch);
        sfxSource.PlayOneShot(clip);
    }

    public void PlayShoot()
    {
        PlayClip(shootClip);
    }

    public void PlayHit()
    {
        PlayClip(hitClip);
    }

    public void PlayDeath()
    {
        PlayClip(deathClip);
    }
    public void PlayHeal()
    {
        PlayClip(healClip);
    }
    public void PlayShield()
    {
        PlayClip(shieldClip);
    }
}