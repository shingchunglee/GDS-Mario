using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EntityMovement : MonoBehaviour
{
  public float speed = 1f;
  public Vector2 direction = Vector2.right;

  private new Rigidbody2D rigidbody;
  public Vector2 velocity;

  private LayerMask layerMask;

  private void Awake()
  {
    rigidbody = GetComponent<Rigidbody2D>();
    layerMask = LayerMask.GetMask("Default");
    enabled = false;
  }

  private void FixedUpdate()
  {
    velocity.x = GetHorizontalVelocity();
    velocity.y += GetVerticalVelocity();

    MovePosition();

    if (IsHitWall())
    {
      direction = -direction;
    }

    if (IsHitFloor())
    {
      velocity.y = Mathf.Max(velocity.y, 0f);
    }
  }


  private float GetHorizontalVelocity()
  {
    return direction.x * speed;
  }

  private float GetVerticalVelocity()
  {
    return Physics2D.gravity.y * Time.fixedDeltaTime;
  }


  private bool IsHitFloor()
  {
    RaycastHit2D hit = Physics2D.Raycast(rigidbody.position, Vector2.down, 0.1f, layerMask);

    return hit.collider != null && hit.rigidbody != rigidbody;
  }

  private bool IsHitWall()
  {
    RaycastHit2D hit = Physics2D.Raycast(rigidbody.position, direction, 0.1f, layerMask);

    return hit.collider != null && hit.rigidbody != rigidbody;
  }

  private void MovePosition()
  {
    rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
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
    rigidbody.WakeUp();
  }

  private void OnDisable()
  {
    rigidbody.velocity = Vector2.zero;
    rigidbody.Sleep();
  }
}