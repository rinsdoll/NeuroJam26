using TMPro;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] AudioClip[] bgmClips;
    AudioSource bgmAudioSource;
    int clipIndex = 0;
    [SerializeField] TextMeshProUGUI songText;
    [SerializeField] string[] songTitles;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        bgmAudioSource = GetComponent<AudioSource>();
        bgmAudioSource.clip = bgmClips[clipIndex];
        songText.text = songTitles[clipIndex];
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
        songText.text = songTitles[clipIndex];
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
        songText.text = songTitles[clipIndex];
        bgmAudioSource.Play();
    }

}
