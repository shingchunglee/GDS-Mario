using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class ExitGame : MonoBehaviour
{
    public int enterGameIndex = 0;
    private Camera cameraScript;

    private void Start()
    {
        cameraScript = Camera.main;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            cameraScript.GetComponent<CameraFollow>().enabled = false;
            Invoke(nameof(EnterGameScene), 1f);
        }
    }

    private void EnterGameScene()
    {
        SceneManager.LoadScene(enterGameIndex);
    }
}
