using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameManager.Inst.MarioPlayer.transform;
    }

    void LateUpdate()
    {
        // Check if the player exists to avoid errors
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x,
                transform.position.y, transform.position.z);
        }
    }
}
