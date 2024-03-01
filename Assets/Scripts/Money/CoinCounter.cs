using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CoinCounter : MonoBehaviour
{

    public static CoinCounter instance;
    public Text score;
    private int scorevalue = 0;

    void OntriggerEnter2D(Collider2D collision)

    {
       if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            scorevalue += 1;
            SetScore();

        }
    }

    void SetScore()
    {

        score.text = "Coins: " + scorevalue;
    }

    //void Awake()
    //{
    //    instance = this;

    //}


















    //// Start is called before the first frame update
    //void Start()
    //{
    //    coinText.text = "Coins: " + currentCoins.ToString();


    //}

    //// Start is called before the first frame update
    //void Update()
    //{
    //    coinText.text = coinCount.ToString();

    //}
    //public void IncreaseCoins(int v) {

    //    currentCoins += v;
    //    coinText.text = "Coins:  " + coinCount.ToString();


    //}
}
