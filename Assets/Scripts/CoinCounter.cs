using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI coinText;

    public Progression prog;


    void Start()
    {
        if (prog == null)
        {
            prog = Object.FindAnyObjectByType<Progression>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + prog.coins.ToString();
    }

    public void CoinSpawn()
    {
        prog.coins+= 10;
    }

}
