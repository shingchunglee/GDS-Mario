using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa_Shell : MonoBehaviour

{
public Sprite shellSprite;

    
    private void OnCollisionEnter2D(Collision2D km_collision) 
    //km_collision between koopa and mario
    // Start is called before the first frame update
    
    {
        
        if(km_collision.gameObject.CompareTag("Player")) //placeholder for mario's tag
        {
             if (km_collision.transform.DotTest(transform, Vector2.down))
             {
                Entershell();

             }
        }
    }

    private void Entershell()
    {
        
        GetComponent<Enemy_Movement>().enabled = false;
        GetComponent<Goomba_AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = shellSprite;
        
    }

}
