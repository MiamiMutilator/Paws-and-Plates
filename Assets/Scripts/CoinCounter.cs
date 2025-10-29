using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI coinText;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }

    public void CoinSpawn()
    {
        coinCount+= 10;
    }

}
