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

    private void Awake()
    {
        // This make sure that only one instance of the GameManager class can exist at a time.
        if (Inst == null)
        {
            Inst = this;
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

        if (Lives > 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else {
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
}
