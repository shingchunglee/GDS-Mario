using UnityEngine;

public abstract class BaseMovementState
{
    public abstract void EnterState(MarioMovementStateManager stateManager);

    public abstract void UpdateState(MarioMovementStateManager stateManager);
}
