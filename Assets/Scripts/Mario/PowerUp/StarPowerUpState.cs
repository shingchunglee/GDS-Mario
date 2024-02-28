using System;
using UnityEngine;

public class StarPowerUpState : DefaultPowerUpState
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

  internal override void OnCollideGoomba(PowerUpStateManager stateManager, GameObject goomba, bool isStomping)
  {
    // TODO: Kill Goomba
    Debug.Log("Kill Goomba");
  }
}
