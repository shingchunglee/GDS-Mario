using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player")){
        Collect(other.gameObject);
    }
}

private void Collect(GameObject player)
{
    GameManager.Inst.AddLife();
    Destroy(gameObject);
}
}
