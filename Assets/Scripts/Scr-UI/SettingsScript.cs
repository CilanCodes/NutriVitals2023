using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] private Button AudioUIButton;
    [SerializeField] private Button SoundsUIButton;
    [SerializeField] private Sprite[] resources;

    private void Update()
    {
        bool isAudioMuted = FindObjectOfType<MusicManager>().IsAudioMuted;
        bool isSoundsMuted = FindObjectOfType<SoundManager>().IsSoundsMuted;


        AudioUIButton.image.sprite =
            SimpleInput.GetButton("OnAudio")
            ? !isAudioMuted
                ? resources[0] //Pressed UnMute
                : resources[1] //Pressed Mute
            : !isAudioMuted
                ? resources[2] //Default UnMute
                : resources[3]; //Default Mute

        SoundsUIButton.image.sprite =
            SimpleInput.GetButton("OnSounds")
            ? !isSoundsMuted
                ? resources[4]
                : resources[5]
            : !isSoundsMuted
                ? resources[6]
                : resources[7];


        if (SimpleInput.GetButtonDown("OnAudio"))
        {
            FindObjectOfType<MusicManager>().OnIsAudioOn();
        }

        if (SimpleInput.GetButtonDown("OnSounds"))
        {
            FindObjectOfType<SoundManager>().OnIsSoundsOn();
        }


    }
}
