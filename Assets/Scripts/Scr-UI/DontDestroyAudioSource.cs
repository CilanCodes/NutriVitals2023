
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyAudioSource : MonoBehaviour
{

    [HideInInspector] public bool isMuted;

    void Awake()
    {

        handleAudio();

    }

    void Start()
    {
        //0 -> no sound
        //1 -> with sound

        int musicIsMuted = PlayerPrefs.GetInt("MusicIsMuted", 0);
        isMuted = musicIsMuted != 0;

        // 0 != 0 <- true <- muted


    }

    void Update()
    {

        if (!(FindObjectsOfType(GetType()).Length > 1) && FindObjectOfType<BackgroundMusicScript>() != null)
        {

            if (FindObjectOfType<BackgroundMusicScript>().isMuted)
            {

                AudioListener.volume = 0;
                PlayerPrefs.SetInt("MusicIsMuted", 1);
                isMuted = true;

            }
            else
            {

        
                AudioListener.volume = 1;
                PlayerPrefs.SetInt("MusicIsMuted", 0);
                isMuted = false;

            }

        }

        //Once the mentioned index Is Visited The Music object will be destroyed
        /*else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Destroy(gameObject);
        }*/
        else
        {
            AudioListener.volume = isMuted
                ? 0
                : 1;
        }


    }

    private void handleAudio()
    {

        if (FindObjectsOfType(GetType()).Length > 1)
        {

            Destroy(gameObject);

        }
        else
        {

            DontDestroyOnLoad(gameObject);

        }

    }
}
