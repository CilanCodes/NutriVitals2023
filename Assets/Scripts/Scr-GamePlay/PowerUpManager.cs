using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{

    [SerializeField] 
    private GameObject powerUpRaysImage;

    [SerializeField]
    private GameObject powerUpOverlayStatus;

    [SerializeField]
    private Sprite powerupSprite;

    [SerializeField]
    private Sprite dangerSprite;

    private CharacterAnimationController characterAnimationController;
    private Image overlayStatusImage;

    public static bool isNotAnimated;
    public static bool isPowerUpSFXNotPlayed;

    void Start()
    {

        characterAnimationController = FindObjectOfType<CharacterAnimationController>();
        overlayStatusImage = powerUpOverlayStatus.GetComponent<Image>();

    }

    void Update()
    {
        //POWERUP
        if (HUDManager.goPoints == 5
            || HUDManager.growPoints == 5
            || HUDManager.glowPoints == 5)
        {
            if (isNotAnimated)
                characterAnimationController.AnimateToPower();

            StartCoroutine(PowerUpDurationThreeSeconds());


            if (HUDManager.goPoints == 5)
            {
                GoPowerUp();
            }
            else if (HUDManager.growPoints == 5)
            {
                GrowPowerUp();
            }
            else if (HUDManager.glowPoints == 5)
            {
                GlowPowerUp();
            }
            HUDManager.ResetFoodPoints();

        }
        else
        {
            isNotAnimated = true;
        }


        if (StateManager.PowerUpState == StateManager.POWER_UP.POWER_UP)
        {

            overlayStatusImage.sprite = powerupSprite;
            powerUpRaysImage.SetActive(true);

            #region SCALE to 1.4
            StartCoroutine(ScaleDownObject());
            #endregion

            PlayPowerUpMusicOnce();

        }
        else if (StateManager.PowerUpState == StateManager.POWER_UP.NONE)
        {
            isPowerUpSFXNotPlayed = true;

            Transform rayTransform = powerUpRaysImage.GetComponent<Transform>();
            rayTransform.localScale = new Vector3(3f, 3f, 3f);

            overlayStatusImage.sprite = dangerSprite;
            powerUpRaysImage.SetActive(false);

        }


    }

    #region GO POWER UP
    public static void GoPowerUp()
    {
        StateManager.PowerUpState = StateManager.POWER_UP.POWER_UP;
        StateManager.PowerUpTypeState = StateManager.POWER_UP_TYPE.GO;

    }

    #endregion

    #region GROW POWER UP
    public static void GrowPowerUp()
    {
        StateManager.PowerUpState = StateManager.POWER_UP.POWER_UP;
        StateManager.PowerUpTypeState = StateManager.POWER_UP_TYPE.GROW;

    }

    #endregion

    #region GLOW POWER UP
    public static void GlowPowerUp()
    {
        StateManager.PowerUpState = StateManager.POWER_UP.POWER_UP;
        StateManager.PowerUpTypeState = StateManager.POWER_UP_TYPE.GLOW;

    }

    #endregion

    #region SPECIAL  POWER UPS

    #endregion

    #region POWER UP RESET AFTER 3 SECONDS
    private static IEnumerator PowerUpDurationThreeSeconds()
    {
        yield return new WaitForSeconds(5f);
        
        StateManager.PowerUpTypeState = StateManager.POWER_UP_TYPE.NONE;

        yield return new WaitForSeconds(3f);
        StateManager.PowerUpState = StateManager.POWER_UP.NONE;
    }
    #endregion

    private IEnumerator ScaleDownObject()
    {
        Transform rayTransform = powerUpRaysImage.GetComponent<Transform>();

        Vector3 originalScale = rayTransform.localScale;
        Vector3 destinationScale = new Vector3(1.4f, 1.4f, 1.4f);

        float elapsedTime = 0.0f;
        float totalTime = 0.15f; // Change this to adjust the duration of the animation

        while (elapsedTime < totalTime)
        {
            rayTransform.localScale = Vector3.Lerp(originalScale, destinationScale, elapsedTime / totalTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rayTransform.localScale = destinationScale;
    }

    public void PlayPowerUpMusicOnce()
    {
        if (isPowerUpSFXNotPlayed)
        {
            FindObjectOfType<SoundManager>().PlayPowerUp();
            isPowerUpSFXNotPlayed = false;
        }
    }
}