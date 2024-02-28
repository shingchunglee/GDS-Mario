using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba_Stomp : MonoBehaviour
{
    public Sprite flatSprite;

    private void OnCollisionEnter2D(Collision2D gm_collision)
    //gm_collision between goomba and mario
    // Start is called before the first frame update

    {
        if (gm_collision.gameObject.CompareTag("Player")) //placeholder for mario's tag
        {
            if (gm_collision.transform.DotTest(transform, Vector2.down))
            {
                Flatten();
            }
        }
    }

    private void Flatten()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Enemy_Movement>().enabled = false;
        GetComponent<Goomba_AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatSprite;
        Destroy(gameObject, 0.5f);
    }

}
