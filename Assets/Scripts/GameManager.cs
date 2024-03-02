using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    public GameObject MarioPlayer;
    public int score;
    public int Lives = 3;
    public Vector2 startPos;
    SpriteRenderer spriteRenderer;

    public int coins = 0;
    [SerializeField] private Text coinText;
   
   public GameObject ResetScreen;
   public GameObject gameOver;
   public Text lifeText;

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
         ResetScreen.SetActive(false);
         gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetLevelDelay(float delay)
    {
        StartCoroutine(ResetLevelCoroutine(delay));
    }

    private IEnumerator ResetLevelCoroutine(float delay)
    {
       
        Lives--;

        lifeText.text = Lives.ToString();

        

        if (Lives > 0)
        {
   
            spriteRenderer.enabled = false;

            ResetScreen.SetActive(true);
            yield return new WaitForSeconds(2f);
            ResetScreen.SetActive(false);


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
        
        gameOver.SetActive(true);
        StartCoroutine(GameOverCoroutine());
    }

    private IEnumerator GameOverCoroutine()
    {
        
        yield return new WaitForSeconds(3f);
        //gameOver.SetActive(false);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;
        
        
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        
    }

    public void AddLife()
    {
        Lives++;
    }

    public void LoseLife()
    {
        Lives--;
    }

    public void AddCoins()
    {
        coins++;

        if (coins == 100)
        {
            AddLife();
            coins = 0;

        }

        coinText.text = "coins:" + coins;
    }

}

