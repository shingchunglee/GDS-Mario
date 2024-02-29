using UnityEngine;

public class MarioIdleMovementState : DefaultMovementState
{
  public override void EnterState(MarioMovementStateManager stateManager)
  {
    stateManager.animationManager.SetMovementState(MarioMovement.Idle);
  }

  public override void UpdateState(MarioMovementStateManager stateManager)
  {

  }
}
