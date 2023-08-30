using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    [SerializeField] public AudioSource eatGoodSoundEffects;
    [SerializeField] public AudioSource eatBadSoundEffects;

    public static void PlayEatGoodSoundEffect()
    {
        SoundEffectsManager soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
        if (soundEffectsManager != null && soundEffectsManager.eatGoodSoundEffects != null)
        {
            soundEffectsManager.eatGoodSoundEffects.Play();
        }
    }

    public static void PlayEatBadSoundEffect()
    {
        SoundEffectsManager soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
        if (soundEffectsManager != null && soundEffectsManager.eatBadSoundEffects != null)
        {
            soundEffectsManager.eatBadSoundEffects.Play();
        }
    }
}
