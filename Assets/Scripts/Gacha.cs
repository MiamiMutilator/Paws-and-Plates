using UnityEngine;
using TMPro;
using System.Collections;

public class Gacha : MonoBehaviour
{
    public int Burger;
    public int Pizza;
    public int Coffee;
    public int Donut;
    public int Latte;

    public int RollNumber;

    public int randomSeed;

    //gacha probabilities
    private int[] weights = { 50, 30, 10, 7, 3 };
    private int totalWeight;

    public TextMeshProUGUI rollText;
    public TextMeshProUGUI BurgerText;
    public TextMeshProUGUI PizzaText;
    public TextMeshProUGUI CoffeeText;
    public TextMeshProUGUI DonutText;
    public TextMeshProUGUI LatteText;


    public Canvas inventoryCanvas;
    public Canvas gachaCanvas;

    public CoinCounter cc;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomSeed = Random.Range(0, 15);
        Random.InitState(randomSeed);

        foreach (int w in weights)
        {
            totalWeight += w;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RollButton()
    {
        if (cc != null && cc.coinCount >= 6)
        {
            RollNumber = GetWeightedRandom();
            StartCoroutine("Rolling");
            cc.coinCount -= 6;
            Debug.Log("Roll made!");
        }
        else
        {
            rollText.text = "Not enough coins!";
        }

    }

    public void InventoryButton()
    {
        inventoryCanvas.gameObject.SetActive(true);
        gachaCanvas.gameObject.SetActive(false);
    }
    public void BackButton()
    {
        inventoryCanvas.gameObject.SetActive(false);
        gachaCanvas.gameObject.SetActive(true);
        rollText.text = "Press Roll!";
    }

    private int GetWeightedRandom()
    {
        int r = Random.Range(0, totalWeight);
        int sum = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            sum += weights[i];
            if (r < sum)
                return i;
        }

        return 0;
    }

    private IEnumerator Rolling()
    {
        rollText.text = "Rolling...";
        yield return new WaitForSeconds(1);

        switch (RollNumber)
        {
            case 0:
                bool alreadyGotBurger = Burger > 0;
                Burger++;
                rollText.text = "Burger " + weights[RollNumber] + "% chance";
                if (Burger > 0)
                {
                    BurgerText.text = "Burger";

                }
                if (alreadyGotBurger && cc != null)
                {
                    cc.coinCount += 1;
                    rollText.text = "Already gotten Burger, 1 coin refund!";
                }
                break;
            case 1:
                bool alreadyGotPizza = Pizza > 0;
                Pizza++;
                rollText.text = "Pizza " + weights[RollNumber] + "% chance";
                if (Pizza > 0)
                {
                    PizzaText.text = "Pizza";

                }
                if (alreadyGotPizza && cc != null)
                {
                    cc.coinCount += 2;
                    rollText.text = "Already gotten Pizza, 2 coin refund!";
                }
                break;
            case 2:
                bool alreadyGotCoffee = Coffee > 0;
                Coffee++;
                rollText.text = "Coffee " + weights[RollNumber] + "% chance";
                if (Coffee > 0)
                {
                    CoffeeText.text = "Coffee";

                }
                if (alreadyGotCoffee && cc != null)
                {
                    cc.coinCount += 3;
                    rollText.text = "Already gotten Coffee, 3 coin refund!";
                }
                break;
            case 3:
                bool alreadyGotDonut = Donut > 0;
                Donut++;
                rollText.text = "Donut " + weights[RollNumber] + "% chance";
                if (Donut > 0)
                {
                    DonutText.text = "Donut";

                }
                if (alreadyGotDonut && cc != null)
                {
                    cc.coinCount += 4;
                    rollText.text = "Already gotten Donut, 4 coin refund!";
                }
                break;
            case 4:
                bool alreadyGotLatte = Latte > 0;
                Latte++;
                rollText.text = "Latte " + weights[RollNumber] + "% chance";
                if (Latte > 0)
                {
                    LatteText.text = "Latte";

                }
                if (alreadyGotLatte && cc != null)
                {
                    cc.coinCount += 6;
                    rollText.text = "Already gotten Latte, 6 coin refund!";
                }
                break;

        }
    }
}
