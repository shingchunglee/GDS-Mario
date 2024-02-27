using UnityEngine;

public class SmallPowerUpState : BasePowerUpState
{
    public override void EnterState(PowerUpStateManager stateManager)
    {

    }

    public override void OnTriggerEnterMushroom(
        PowerUpStateManager stateManager,
        GameObject mushroom
    )
    {
        stateManager.SwitchState(stateManager.bigPowerUpState);
        GameObject.Destroy(mushroom);
    }

    public override void UpdateState(PowerUpStateManager stateManager)
    {

    }
}
