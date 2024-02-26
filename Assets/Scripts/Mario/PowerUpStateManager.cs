using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpStateManager : MonoBehaviour
{
    public BasePowerUpState currentState;
    public SmallPowerUpState smallPowerUpState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = smallPowerUpState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BasePowerUpState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
