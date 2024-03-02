using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnimation : MonoBehaviour
{
    private Animator flagDown; 

    private void Start()
    {
       flagDown = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            flagDown.enabled = true;
        }
    }
}
