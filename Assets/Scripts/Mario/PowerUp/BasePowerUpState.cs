using UnityEngine;

public abstract class BasePowerUpState
{
    public abstract void EnterState(PowerUpStateManager stateManager);

    public abstract void UpdateState(PowerUpStateManager stateManager);

    public abstract void OnTriggerEnterMushroom(PowerUpStateManager stateManager, GameObject mushroom);
    internal abstract void OnCollideGoomba(PowerUpStateManager stateManager, GameObject goomba, bool isStomping);

    internal abstract void OnCollideKoopa(PowerUpStateManager stateManager, GameObject koopa, bool isStomping);
}
