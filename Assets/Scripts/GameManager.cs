using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    public GameObject MarioPlayer;
    public int score;
    public int Lives = 3;
    public Vector2 startPos;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        // This make sure that only one instance of the GameManager class can exist at a time.
        if (Inst == null)
        {
            Inst = this;
            spriteRenderer = MarioPlayer.GetComponent<SpriteRenderer>();
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetLevelDelay(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        Lives--;
        transform.position = startPos;
        if (Lives > 0)
        {
            spriteRenderer.enabled = false;

            MarioPlayer.transform.position = startPos;
            spriteRenderer.enabled = true;
        }
        else
        {
            GameOver();
        }

       
    }

    private void GameOver()
{
    // for now
    Debug.Log("Game Over!");
}

    public void AddLife()
    {
        Lives++;
    }

    public void LoseLife()
    {
        Lives--;
    }
}
