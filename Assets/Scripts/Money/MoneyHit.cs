using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneyHit : MonoBehaviour
{
    public static GameManager Inst;

    // Start is called before the first frame update
    private  void Start()
    {
        GameManager.Inst.AddCoins();
        StartCoroutine(Animate());

        
    }

    private IEnumerator Animate()
    {
       
        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 2f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        Destroy(gameObject);


    }


    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.25f; // The duration over which the movement happens

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.localPosition = Vector3.Lerp(from, to, t); // Correctly interpolate between from and to
            elapsed += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        transform.localPosition = to; // Ensure the object ends up at the target position
    }


}

