using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPowerUpState : BasePowerUpState
{
    public override void EnterState(PowerUpStateManager stateManager)
    {
    }

    public override void OnTriggerEnterMushroom(PowerUpStateManager stateManager)
    {
        stateManager.SwitchState(stateManager.bigPowerUpState);
    }

    public override void UpdateState(PowerUpStateManager stateManager)
    {
    }
}
