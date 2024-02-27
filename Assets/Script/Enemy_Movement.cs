using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction = Vector2.left;
    
    private Rigidbody2D e_rigidbody;
    private Vector2 velocity;

    private void Awake()
    {
        e_rigidbody = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        e_rigidbody.WakeUp();
    }
    private void OnDisable()
    {
        e_rigidbody.velocity = Vector2.zero;
        e_rigidbody.Sleep();
    }

    private void FixedUpdate()
    {
        velocity.x = direction.x * speed;
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        e_rigidbody.MovePosition(e_rigidbody.position + velocity * Time.fixedDeltaTime);

        if (e_rigidbody.Raycast(direction)) {
            direction = -direction;
        }

        if (e_rigidbody.Raycast(Vector2.down)) {
            velocity.y = Mathf.Max(velocity.y, 0f);
        }
    }
}
