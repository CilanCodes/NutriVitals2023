using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] playlistMusic;

    private AudioSource audioSource;

    private float isAudioOn;

    public static int musicIndex;

    void Update()
    {

        if (audioSource == null)
        {

            isAudioOn = PlayerPrefs.GetFloat("is_audio_on", 0.5f);

            audioSource = FindObjectOfType<Music>().AudioSource;
            audioSource.loop = false;
            audioSource.volume = isAudioOn;

        }

        if (!audioSource.isPlaying)
        {

            audioSource.clip = playlistMusic[musicIndex];
            audioSource.Play();

        }

    }

    private void IsAudioOn()
    {

        isAudioOn = isAudioOn != 0
            ? 0
            : 0.5f;

        audioSource.volume = isAudioOn;
        PlayerPrefs.SetFloat("is_audio_on", isAudioOn);

    }

    public bool IsAudioMuted => isAudioOn == 0;

    public void OnIsAudioOn() => IsAudioOn();
}
