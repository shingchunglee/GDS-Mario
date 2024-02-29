using System;
using System.Collections;
using UnityEngine;

public enum MarioMovement
{
    Idle, Run, Jump, Slide
}

public enum MarioPowerUp
{
    Dead, Small, Big
}

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetMovementState(MarioMovement movementState)
    {
        animator.SetInteger("movement_state", (int)movementState);
    }

    public void SetPowerUpState(MarioPowerUp powerUpState)
    {
        animator.SetInteger("power_up_state", (int)powerUpState);
    }
}
