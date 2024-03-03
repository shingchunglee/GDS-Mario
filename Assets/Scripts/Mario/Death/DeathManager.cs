using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private Vector2 velocity;
    private new Rigidbody2D rigidbody;
    private new Collider2D collider2D;
    private AnimationManager animationManager;

    private float jumpHeight = 8f;
    private float jumpTime = 1f;
    private float jumpForce => jumpHeight / jumpTime;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        animationManager = GetComponent<AnimationManager>();
        enabled = false;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        velocity.y += GetVerticalVelocity();

        MovePosition();
    }

    public float GetVerticalVelocity()
    {
        return Physics2D.gravity.y * Time.fixedDeltaTime;
    }

    public void Jump()
    {
        velocity.y = jumpForce;
    }

    public void MovePosition()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "KillBox")
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        GameManager.Inst.PauseMusic();
        GameManager.Inst.PlayDeathSound();

        enabled = true;
        // TODO: Lives -1
        // GameManager.Inst.LoseLife();

        // TODO: Take Over Movement
        gameObject.GetComponent<PlayerController2D>().StopPlayerMovement();

        // Jump
        Jump();

        // deactivate colliders
        collider2D.enabled = false;

        // TODO: Death Animation
        animationManager.SetPowerUpState(MarioPowerUp.Dead);

        GameManager.Inst.ResetLevelDelay(3f);
    }

    public void OnRespawn()
    {
        // activate movement component

        // activate colliders
        collider2D.enabled = true;
    }
}
