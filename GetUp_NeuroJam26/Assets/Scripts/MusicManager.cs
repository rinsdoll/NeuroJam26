using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] AudioClip[] bgmClips;
    AudioSource bgmAudioSource;
    int clipIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        bgmAudioSource = GetComponent<AudioSource>();
        bgmAudioSource.clip = bgmClips[clipIndex];
    }

    private void Start()
    {
        bgmAudioSource.Play();
    }

    public void PlayNextSong()
    {
        if (clipIndex <  bgmClips.Length - 1)
        {
            clipIndex++;
        }
        else
        {
            clipIndex = 0;
        }

        bgmAudioSource.Stop();
        bgmAudioSource.clip = bgmClips[clipIndex];
        bgmAudioSource.Play();
    }

    public void PlayPreviousSong()
    {
        if (clipIndex > 0)
        {
            clipIndex--;
        }
        else
        {
            clipIndex = bgmClips.Length - 1;
        }

        bgmAudioSource.Stop();
        bgmAudioSource.clip = bgmClips[clipIndex];
        bgmAudioSource.Play();
    }

}
