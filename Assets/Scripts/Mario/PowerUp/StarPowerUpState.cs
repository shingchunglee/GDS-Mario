using System;
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

  internal void OnTriggerEnterStar(PowerUpStateManager powerUpStateManager, GameObject star)
  {
    GameObject.Destroy(star);
  }

  public override void UpdateState(PowerUpStateManager stateManager)
  {

  }


}
