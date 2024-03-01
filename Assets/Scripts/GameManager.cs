using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    public GameObject MarioPlayer;
    public int score;
    public int coins; 
   
    private int lives;

    
    public static object Instance { get; internal set; }

    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        lives = 3;
        coins = 0;

    }
  

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

    public void AddCoins()
    {
        coins++;

        if (coins == 100)
        {
            AddLife();
            coins = 0;

        }
    }

    public void AddLife()
    {
        GameManager.Inst.AddLife();
        lives++;

    }
}

