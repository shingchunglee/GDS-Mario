using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    public GameObject MarioPlayer;
    public int score;
    public int Lives;
    public Vector2 startPos;
    SpriteRenderer spriteRenderer;

    public int coins = 0;
    [SerializeField] private Text coinText;
   
   public GameObject ResetScreen;
   public GameObject gameOver;
   public Text lifeText;

    public int targetFrameRate = 30;

    private void Awake()
    {
        // This make sure that only one instance of the GameManager class can exist at a time.
        if (Inst == null)
        {
            Inst = this;
            spriteRenderer = MarioPlayer.GetComponent<SpriteRenderer>();

            LoadSceneSetup();
        }
        else
        {
            Destroy(this);
        }
    }

    /// <summary>
    /// Put all start of game setup tasks in here.
    /// </summary>
    private void LoadSceneSetup()
    {
        ResetScreen.SetActive(false);
        gameOver.SetActive(false);

        QualitySettings.vSyncCount = 0; Application.targetFrameRate = targetFrameRate;

        if (PlayerPrefs.HasKey("Lives"))
        {
            Lives = PlayerPrefs.GetInt("Lives");
            Debug.Log($"Lives = {Lives}");
        }
        else
        {
            Lives = 3;
            Debug.Log($"Lives not saved under PlayerPrefs, so Lives = {Lives}");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.targetFrameRate != targetFrameRate) Application.targetFrameRate = targetFrameRate;
    }

    public void ResetLevelDelay(float delay)
    {
        StartCoroutine(ResetLevelCoroutine(delay));
    }

    private IEnumerator ResetLevelCoroutine(float delay)
    {
       
        Lives--;

        lifeText.text = Lives.ToString();

        PlayerPrefs.SetInt("Lives", Lives);

        if (Lives > 0)
        {
            yield return new WaitForSeconds(3f);

            spriteRenderer.enabled = false;

            ResetScreen.SetActive(true);
            yield return new WaitForSeconds(2f);

            ReloadLevel();

        }
        else
        {
            
            GameOver();
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene("Stage 01-Sunny");
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
