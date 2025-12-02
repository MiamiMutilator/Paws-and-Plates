using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    public Progression prog;

    void Start()
    {
        prog = Progression.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = prog.coins.ToString();
    }

    public void CoinSpawn()
    {
        prog.coins+= 10;
    }

}
