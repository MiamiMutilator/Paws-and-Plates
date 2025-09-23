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
        RollNumber = Random.Range(0, 5);
        StartCoroutine("Rolling");
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
                Burger++;
                rollText.text = "Burger";
                BurgerText.text = "Burgers: " + Burger;
                break;
            case 1:
                Pizza++;
                rollText.text = "Pizza";
                PizzaText.text = "Pizzas: " + Pizza;

                break;
            case 2:
                Coffee++;
                rollText.text = "Coffee";
                CoffeeText.text = "Coffees: " + Coffee;

                break;
            case 3:
                Donut++;
                rollText.text = "Donut";
                DonutText.text = "Donuts: " + Donut;

                break;
            case 4:
                Latte++;
                rollText.text = "Latte";
                LatteText.text = "Latte: " + Latte;
                break;
        }
    }
}
