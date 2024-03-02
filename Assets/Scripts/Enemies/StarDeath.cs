using UnityEngine;


public class EnemyStarDeath : MonoBehaviour
{
  public void onStarDeath()
  {
    gameObject.transform.Rotate(180f, 0f, 0f);

    gameObject.GetComponent<Enemy_Movement>().enabled = false;

    Collider2D[] colliders = gameObject.GetComponents<Collider2D>();
    foreach (var collider in colliders)
    {
      collider.enabled = false;
    }

    var rigidbody = GetComponent<Rigidbody2D>();
    if (rigidbody != null)
    {
      rigidbody.AddForce(Vector3.up * 1f, ForceMode2D.Impulse);
      rigidbody.excludeLayers = LayerMask.GetMask("Default");
    }
  }
}
