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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RollButton()
    {
        if (cc != null && cc.coinCount >= 6)
        {
            RollNumber = Random.Range(0, 5);
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

    private IEnumerator Rolling()
    {
        rollText.text = "Rolling...";
        yield return new WaitForSeconds(1);

        switch (RollNumber)
        {
            case 0:
                bool alreadyGotBurger = Burger > 0;
                Burger++;
                rollText.text = "Burger";
                BurgerText.text = "Burgers: " + Burger;
                if (alreadyGotBurger && cc != null)
                {
                    cc.coinCount += 3;
                    rollText.text = "Already gotten, 3 coin refund!";
                }
                break;
            case 1:
                bool alreadyGotPizza = Pizza > 0;
                Pizza++;
                rollText.text = "Pizza";
                PizzaText.text = "Pizzas: " + Pizza;
                if (alreadyGotPizza && cc != null)
                {
                    cc.coinCount += 3;
                    rollText.text = "Already gotten, 3 coin refund!";
                }
                break;
            case 2:
                bool alreadyGotCoffee = Coffee > 0;
                Coffee++;
                rollText.text = "Coffee";
                CoffeeText.text = "Coffees: " + Coffee;
                if (alreadyGotCoffee && cc != null)
                {
                    cc.coinCount += 3;
                    rollText.text = "Already gotten, 3 coin refund!";
                }
                break;
            case 3:
                bool alreadyGotDonut = Donut > 0;
                Donut++;
                rollText.text = "Donut";
                DonutText.text = "Donuts: " + Donut;
                if (alreadyGotDonut && cc != null)
                {
                    cc.coinCount += 3;
                    rollText.text = "Already gotten, 3 coin refund!";
                }
                break;
            case 4:
                bool alreadyGotLatte = Latte > 0;
                Latte++;
                rollText.text = "Latte";
                LatteText.text = "Latte: " + Latte;
                if (alreadyGotLatte && cc != null)
                {
                    cc.coinCount += 3;
                    rollText.text = "Already gotten, 3 coin refund!";
                }
                break;

        }
    }
}
