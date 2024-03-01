using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CoinCounter : MonoBehaviour
{

    public static CoinCounter instance;
    public Text coinText;
    public int coinCount;
    public int currentCoins = 0;


     void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        //coinText.text = "COINS: " + currentCoins.ToString();

    }

    public void IncreaseCoins(int v) {

        currentCoins += v;
        coinText.text = "COINS: " + coinCount.ToString();


    }
}
