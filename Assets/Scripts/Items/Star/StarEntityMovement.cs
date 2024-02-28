using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StarEntityMovement : EntityMovement
{
  private float jumpHeight = 4f;
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
  }

  public void Jump()
  {
    velocity.y = jumpForce;
  }

}