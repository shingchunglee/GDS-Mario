using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    public GameObject MarioPlayer;
    public int score;

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
}
