using UnityEngine;

public class SmallPowerUpState : DefaultPowerUpState
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

    internal override void OnCollideGoomba(PowerUpStateManager stateManager, GameObject goomba, bool isStomping)
    {
        if (isStomping)
        {
            // TODO: Kill Goomba
            Debug.Log("Kill Goomba");
            return;
        }
        // TODO: Kill Mario
        Debug.Log("Kill mario");
        stateManager.deathManager.OnDeath();
    }
}
