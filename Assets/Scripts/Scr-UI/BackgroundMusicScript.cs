using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicScript : MonoBehaviour
{
    private Toggle toggleMusic;
    [SerializeField] private Image imageMusic;
    [SerializeField] private Sprite[] buttonDefault;
    [SerializeField] private Sprite[] buttonPressed;


    void Awake()
    {
        toggleMusic = GetComponent<Toggle>();
        isMuted = FindObjectOfType<DontDestroyAudioSource>().isMuted;

    }


    void Update()
    {

        //Make sure to delete the CheckMark Component
        imageMusic.sprite =
            SimpleInput.GetButton("OnToggleMusic")

            ? buttonPressed[isMuted
                ? 0 //muted music clicked
                : 1] //play music clicked
            : buttonDefault[isMuted ? 0 : 1];

    }



    public bool isMuted
    {

        set { toggleMusic.isOn = value; }
        get { return toggleMusic.isOn; }

    }

}
