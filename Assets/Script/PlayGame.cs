using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public GameObject panel; 
    public float delay = 3.0f; 
    public int gameStartIndex = 1;
    private int startingLives = 3;

    void Start()
    {
        panel.SetActive(false);

        PlayerPrefs.SetInt("Lives", startingLives);
        PlayerPrefs.Save();

        Debug.Log($"Lives = {startingLives}");


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartGameAfterDelay());
        }
    }

    IEnumerator StartGameAfterDelay()
    {
        panel.SetActive(true); 
        yield return new WaitForSeconds(delay); 
        
        SceneManager.LoadScene(gameStartIndex); 
    }
}