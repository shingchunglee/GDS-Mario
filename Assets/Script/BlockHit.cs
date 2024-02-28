using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
public int maxHits = -1;
public Sprite emptyBlock;

private bool animating;

    private void OnCollisionEnter2D(Collision2D bm_collision)
    //bm - block mario
    {
        if(!animating && bm_collision.gameObject.CompareTag("Player"))
        if (bm_collision.transform.DotTest(transform, Vector2.up)){
            Hit();
        }
    }

    private void Hit()
{
    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    maxHits--; // Assuming maxHits is the correct variable name
    if (maxHits == 0)
    {
        spriteRenderer.sprite = emptyBlock;
    }
    StartCoroutine(Animate());
}

private IEnumerator Animate()
{
    animating = true;
    Vector3 restingPosition = transform.localPosition;
    Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;

    yield return Move(restingPosition, animatedPosition);
    yield return Move(animatedPosition, restingPosition);

    animating = false;
}


private IEnumerator Move(Vector3 from, Vector3 to)
{
    float elapsed = 0f;
    float duration = 0.125f; // The duration over which the movement happens

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
