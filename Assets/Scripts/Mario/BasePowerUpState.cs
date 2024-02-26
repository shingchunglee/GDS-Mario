using UnityEngine;

public abstract class BasePowerUpState
{
    public abstract void EnterState(PowerUpStateManager stateManager);

    public abstract void UpdateState(PowerUpStateManager stateManager);
}
