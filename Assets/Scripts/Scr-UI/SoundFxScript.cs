using UnityEngine;
using UnityEngine.UI;

public class SoundFxScript : MonoBehaviour
{
    
    private Toggle toggleSound;
    [SerializeField] private Image imageSound;
    [SerializeField] private Sprite[] buttonDefault;
    [SerializeField] private Sprite[] buttonPressed;


    void Awake()
    {
        toggleSound = GetComponent<Toggle>();
        isMuted = FindObjectOfType<DontDestroyAudioSource>().isMuted;

    }


    void Update()
    {
        
        //Make sure to delete the CheckMark Component
        imageSound.sprite =
            SimpleInput.GetButton("OnToggleSound")
            ? buttonPressed[toggleSound.isOn
                ? 0 //muted sound clicked
                : 1 ] //muted sound clicked
            : buttonDefault[toggleSound.isOn ? 0 : 1];

    }

 

    public bool isMuted
    {

        set { toggleSound.isOn = value; }
        get { return toggleSound.isOn; }

    }

}
