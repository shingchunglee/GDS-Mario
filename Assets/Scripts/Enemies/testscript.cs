using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player")) // Assuming your enemy has the tag "Enemy"
    {
        GameManager.Inst.ResetLevelDelay(1f); // Delay before reset, adjust as needed
    }
}
}
