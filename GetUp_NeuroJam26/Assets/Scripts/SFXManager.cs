using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    AudioSource sfxAudioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        sfxAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX()
    {
        sfxAudioSource.Play();
    }
}
