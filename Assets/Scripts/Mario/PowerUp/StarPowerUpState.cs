using UnityEngine;

public class StarPowerUpState : BasePowerUpState
{
  public bool isActive { get; private set; } = false;

  public override void EnterState(PowerUpStateManager stateManager)
  {
    isActive = true;
  }

  public override void OnTriggerEnterMushroom(
      PowerUpStateManager stateManager,
      GameObject mushroom
  )
  {
    stateManager.currentState.OnTriggerEnterMushroom(stateManager, mushroom);
  }

  public override void UpdateState(PowerUpStateManager stateManager)
  {

  }
}
