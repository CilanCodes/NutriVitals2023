using UnityEngine;

public class AdjustmentFunctions : MonoBehaviour
{

    public static void DecreaseEnergyOverTime()
    {
        #region ENERGY BURN

        if (StateManager.EnergyState == StateManager.ENERGY.HIGH_DANGER)
        {
            HUDManager.UpdateScoreEnergyPoints(0, -.0015f);
        }
        else if (StateManager.EnergyState == StateManager.ENERGY.LOW_DANGER)
        {
            HUDManager.UpdateScoreEnergyPoints(0, -.00025f);
        }
        else
        {
            HUDManager.UpdateScoreEnergyPoints(0, -.00075f);
        }

        #endregion
    }

    public static void GoodFoodBenefits(int multiplier)
    {
        // GENERAL GOOD FOOD BENEFITS
        if (StateManager.EnergyState == StateManager.ENERGY.LOW_DANGER)
        {
            HUDManager.UpdateScoreEnergyPoints(25 * multiplier, .075f);
        }
        else if (StateManager.EnergyState == StateManager.ENERGY.LOW_WARNING)
        {
            HUDManager.UpdateScoreEnergyPoints(25 * multiplier, .050f);
        }
        else
        {
            HUDManager.UpdateScoreEnergyPoints(25 * multiplier, .025f);
        }
    }
}
