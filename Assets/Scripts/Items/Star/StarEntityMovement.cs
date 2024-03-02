using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StarEntityMovement : EntityMovement
{
  private float jumpHeight = 8f;
  private float jumpTime = 1f;
  private float jumpForce => jumpHeight / jumpTime;

  new private void FixedUpdate()
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
      Jump();
    }

    if (IsHitCelling())
    {
      velocity.y = 0f;
    }
  }

  private bool IsHitCelling()
  {
    Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
    RaycastHit2D hit = Physics2D.Raycast(rigidbody.position, Vector2.up, 0.5f, base.layerMask);

    return hit.collider != null && hit.rigidbody != rigidbody;
  }

  public void Jump()
  {
    velocity.y = jumpForce;
  }

}