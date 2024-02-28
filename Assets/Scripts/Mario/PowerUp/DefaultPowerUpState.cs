using UnityEngine;

public class DefaultPowerUpState : BasePowerUpState
{
    public override void EnterState(PowerUpStateManager stateManager)
    {

    }

    public override void OnTriggerEnterMushroom(
        PowerUpStateManager stateManager,
        GameObject mushroom
    )
    {
        GameObject.Destroy(mushroom);
    }

    public override void UpdateState(PowerUpStateManager stateManager)
    {

    }

    internal override void OnCollideGoomba(PowerUpStateManager stateManager, GameObject goomba, bool isStomping)
    {
        if (isStomping)
        {
            // TODO: Kill Goomba
            Debug.Log("Kill Goomba");
            return;
        }

        // Turn to small mario

        Debug.Log("small mario");
        stateManager.SwitchState(stateManager.smallPowerUpState);
    }
}
