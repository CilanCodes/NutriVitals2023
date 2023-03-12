using UnityEngine;

public class StateManager : MonoBehaviour
{

    private static ENERGY energyState;
    private static POWER_UP powerUpState;
    private static POWER_UP_TYPE powerUpTypeState;
    private static HIT hitState;
    private static bool isMoving;

    public enum ENERGY 
    { 

        HIGH_WARNING, 
        LOW_WARNING, 
        BALANCED, 
        LOW_DANGER, 
        HIGH_DANGER,
        DRUNK
            
    }

    public enum POWER_UP 
    { 

        NONE,
        POWER_UP

    }

    public enum POWER_UP_TYPE 
    { 

        NONE,
        GO, 
        GROW, 
        GLOW,

    }

    public enum HIT 
    { 

        GO, 
        GROW, 
        GLOW, 
        JUNK, 

    }

    void Start()
    {

        PowerUpState = POWER_UP.NONE;
        PowerUpTypeState = POWER_UP_TYPE.NONE;

    }

    private static HIT Hit(string _hit) => _hit switch
    {

        "Go" => HIT.GO,

        "Grow" => HIT.GROW,

        "Glow" => HIT.GLOW,

        _ => HIT.JUNK,

    };

    public static ENERGY EnergyState
    { 
        
        get => energyState; 
        set => energyState = value; 
    
    }

    public static POWER_UP PowerUpState
    {

        get => powerUpState;
        set => powerUpState = value;

    }

    public static POWER_UP_TYPE PowerUpTypeState
    {

        get => powerUpTypeState;
        set => powerUpTypeState = value;

    }

    public static HIT HitState
    {

        get => hitState;
        set => hitState = value;

    }

    public static bool IsMoving
    {

        get => isMoving;
        set => isMoving = value;

    }

    public static HIT GetHit(string _hit) => Hit(_hit);

}
