
using UnityEngine;

public enum MarioMovementStates
{
    idle,
    run,
    jump,
    death
}

public class MarioMovementStateManager : MonoBehaviour
{
    public BaseMovementState currentState;
    public MarioIdleMovementState idleMovementState = new MarioIdleMovementState();


    public AnimationManager animationManager;

    // Start is called before the first frame update
    void Start()
    {
        animationManager = gameObject.GetComponent<AnimationManager>();

        currentState = idleMovementState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseMovementState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
