using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public Rigidbody2D RB;
    public BoxCollider2D PlayerCollider;

    public float MoveSpeed = 2f;
    public float MaxMoveSpeed = 5f;
    public float JumpHeight = 5f;

    private float IncreasedDragThreshold = 6f;
    private float HorizontalDrag = 0.96f;

    private float JumpResetTime = 0.3f;
    public float JumpResetTimer;
    public float inAirMultiplier = 1f;
    public float bouncedMultiplier = 0.3f;

    private bool JumpButton;
    private bool TestButton;


    public bool IsPlayerGrounded;
    public bool IsPlayerOnSlippery;

    [Range(0, 50)]
    public int segments = 50;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        GetPlayerInput();
        DropThroughPlatformCheck(); // Do this in Fixed Update, and add check to GetPlayerInput()
    }

    void GetPlayerInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            JumpButton = true;
        }
        else
        {
            JumpButton = false;
        }
        if (Input.GetKey(KeyCode.T))    //Button used to test things 
        {
            TestButton = true;
        }
        else
        {
            TestButton = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
        TestButtonT();
    }

    public float CurrentDistance;

    void Move()
    {
        //Limits move speed by multiplying by 0 if velocity is over limit
        float maxSpeedLimiter = 1f;
        var maxMoveSpeed = !IsPlayerGrounded ? MaxMoveSpeed * 3f : MaxMoveSpeed;
        if (Math.Abs(RB.velocity.x) >= maxMoveSpeed)
        {
            maxSpeedLimiter = 0f;
        }

        //When Grounded, if stop pressing input, quickly slow to a halt
        if (Input.GetAxisRaw("Horizontal") == 0
            && IsPlayerGrounded
            && !Input.GetKey(KeyCode.Space))        //This lets you hop and maintain momentum
        {
            RB.velocity = new Vector2((RB.velocity.x * 1f), RB.velocity.y);
        }
        else
        {

            ApplyMovementCompensation();

            RB.AddForce(Vector3.right * MoveSpeed *
                        Input.GetAxis("Horizontal") * maxSpeedLimiter *
                        (IsPlayerGrounded ? 1 : inAirMultiplier),        //Bitwise operation
                ForceMode2D.Impulse);
        }

        ApplyDragAtLowVel();

    }

    //When you start moving in the opposite direction to which you are travelling, you get a boost in that direction.
    //Makes it feel more responsive.
    //- This only applies on 'non-short' arrow key presses. A 'short' press
    //is when the button is only tapped.
    // This doesn't happen when you are on a 'slippery' surface, so you slide around more.
    private void ApplyMovementCompensation()
    {
        if (IsPlayerOnSlippery) return;

        float changeCompensation = 3;


        if (Input.GetAxisRaw("Horizontal") > 0
            && RB.velocity.x < 0)
        {
            if (IsPlayerGrounded)
            {
                if (RB.velocity.x > -7)
                {
                    RB.velocity = new Vector2(changeCompensation, RB.velocity.y);
                }
            }
            else
            {
                RB.velocity = new Vector2(RB.velocity.x + (changeCompensation / 1.7f), RB.velocity.y);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0
            && RB.velocity.x > 0)
        {
            if (IsPlayerGrounded)
            {
                if (RB.velocity.x < 7)
                {
                    RB.velocity = new Vector2(-changeCompensation, RB.velocity.y);
                }
            }
            else
            {
                RB.velocity = new Vector2(RB.velocity.x - (changeCompensation / 1.7f), RB.velocity.y);
            }
        }
    }



    /// <summary>
    /// Applies horizontal drag to the player when they are traveling at low
    /// horizontal velocity and not pressing an arrow key. This is so the
    /// player can more accurately control movement.
    /// </summary>
    private void ApplyDragAtLowVel()
    {
        if (IsHorizontalInput() ||
            IsPlayerGrounded)
        {
            return;
        }

        if (RB.velocity.x < IncreasedDragThreshold &&
            RB.velocity.x > -IncreasedDragThreshold)
        {
            var vel = RB.velocity;
            vel.x *= HorizontalDrag;

            RB.velocity = vel;
        }
    }

    // Returns true if player is pressing horizontal arrow keys.
    public bool IsHorizontalInput()
    {
        if (Input.GetAxisRaw("Horizontal") != 0) return true;
        else return false;
    }
    private bool JWork;

    void Jump()
    {
        if (JumpResetTimer > 0)
        {
            JumpResetTimer -= Time.deltaTime;
            JWork = false;
        }
        else
        {
            if (!JWork)
            {
                JWork = true;
            }
        }

        if (JumpButton)
        {
            if (IsPlayerGrounded && JumpResetTimer <= 0)
            {
                RB.velocity = new Vector3(RB.velocity.x, 0, 0);
                RB.AddForce(Vector3.up * JumpHeight, ForceMode2D.Impulse);
                JumpResetTimer = JumpResetTime;
                IsPlayerGrounded = false;
            }
        }
    }

    void DropThroughPlatformCheck()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (oneWayPlatColliders.Count > 0)
            {
                StartCoroutine(DisableCollisionOneWay());
            }
        }
    }

    public List<Collider2D> oneWayPlatColliders;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("OneWayPlatform"))
        {
            oneWayPlatColliders.Add(collision.collider);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("OneWayPlatform"))
        {
            oneWayPlatColliders.Remove(collision.collider);
        }
    }


    // At the moment this turns off every single One Way Platform on the
    // Tilemap_OneWayPlatforms layer. Probably should only turn off the
    // one you are standing on, but this is hard to do.
    public float platformWaitTime;
    private IEnumerator DisableCollisionOneWay()
    {
        var colliders = new List<Collider2D>();
        foreach (var platformCol in oneWayPlatColliders)
        {
            Physics2D.IgnoreCollision(PlayerCollider, platformCol);
            colliders.Add(platformCol);
        }
        yield return new WaitForSeconds(platformWaitTime);

        foreach (var platformCol in colliders)
        {
            Physics2D.IgnoreCollision(PlayerCollider, platformCol, false);
        }

    }

    /// <summary>
    /// This sets grounded to true when "Ground" enters the players trigger.
    ///
    /// Set to false when you press jump.
    /// </summary>
    public BoxCollider2D GroundCheckCollider;
    public GameObject currentGround;
    public bool GroundTrigger = false;
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.transform.tag == "Ground")
        {
            currentGround = collider2D.gameObject;
        }
        if (currentGround != null)
        {
            IsPlayerGrounded = true;
        }
        else
        {
            IsPlayerGrounded = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collider2D)
    {

        if (collider2D.transform.tag == "Ground")
        {
            if (currentGround == collider2D.gameObject)
            {
                currentGround = null;
            }
        }

        if (currentGround != null)
            IsPlayerGrounded = true;
        else
            IsPlayerGrounded = false;

    }




    /// <summary>
    /// Triggered in game if you press 't'.
    /// </summary>
    void TestButtonT()
    {
        if (TestButton)
        {
            // Write test button code here
            Debug.Log("'T' button pressed.");





            // Write test buttone code about this
            TestButton = false;
        }
    }

}
