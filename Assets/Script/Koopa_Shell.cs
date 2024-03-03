using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa_Shell : MonoBehaviour

{
    public Sprite shellSprite;

    public bool isEnteredShell = false;


    // private void OnCollisionEnter2D(Collision2D km_collision) 
    // //km_collision between koopa and mario
    // // Start is called before the first frame update

    // {

    //     if(km_collision.gameObject.CompareTag("Player")) //placeholder for mario's tag
    //     {
    //          if (km_collision.transform.DotTest(transform, Vector2.down))
    //          {
    //             Entershell();

    //          }
    //     }
    // }

    public void onStomp()
    {
        if (!isEnteredShell)
        {
            EnterShell();
        }
        else
        {
            StartCoroutine(KickShell());
        }
    }

    private IEnumerator KickShell()
    {
        var rigidbody2D = GetComponent<Rigidbody2D>();
        var shellSpeed = 5f;
        rigidbody2D.velocity = new Vector2(shellSpeed, rigidbody2D.velocity.y);

        var playerLayer = LayerMask.NameToLayer("Player");
        var originalLayer = gameObject.layer;

        Physics2D.IgnoreLayerCollision(gameObject.layer, playerLayer, true);
        yield return new WaitForSeconds(0.3f);
        Physics2D.IgnoreLayerCollision(originalLayer, playerLayer, false);
    }

    private void EnterShell()
    {
        isEnteredShell = true;
        GetComponent<Enemy_Movement>().enabled = false;
        GetComponent<Goomba_AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = shellSprite;

    }

}
