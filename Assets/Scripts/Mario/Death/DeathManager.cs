using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private Vector2 velocity;
    private new Rigidbody2D rigidbody;
    private new Collider2D collider2D;

    private float jumpHeight = 4f;
    private float jumpTime = 1f;
    private float jumpForce => jumpHeight / jumpTime;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
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

    public void OnDeath()
    {
        enabled = true;
        // TODO: Lives -1

        // TODO: Take Over Movement
        // deactivate movement component 

        // Jump
        Jump();

        // deactivate colliders
        collider2D.enabled = false;

        // TODO: Death Animation

    }

    public void OnRespawn()
    {
        // activate movement component

        // activate colliders
        collider2D.enabled = true;
    }
}
