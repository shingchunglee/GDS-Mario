using UnityEngine;

public class BigPowerUpState : BasePowerUpState
{
  public override void EnterState(PowerUpStateManager stateManager) { }

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
}
