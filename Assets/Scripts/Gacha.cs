using UnityEngine;
using TMPro;
using System.Collections;

public class Gacha : MonoBehaviour
{
    public int BaconEggCheese;
    public int Burger;
    public int CaesarSalad;
    public int Omelette;
    public int Pancakes;
    public int Quesadilla;
    public int ScrambledEggs;
    public int Waffles;
    public int Coffee;
    public int IcedCoffee;
    public int MangoPeachSmoothie;
    public int MatchaLatte;
    public int PineCocoSmoothie;
    public int StrawBanSmoothie;
    public int VanFrappe;




    public int RollNumber;

    public int randomSeed;

    //gacha probabilities
    private int[] weights = { 50, 40, 35, 30, 25, 20, 15, 10, 7, 5, 4, 3, 2, 2, 1 };
    private int totalWeight;

    public TextMeshProUGUI rollText;
    public TextMeshProUGUI BECText;
    public TextMeshProUGUI BurgerText;
    public TextMeshProUGUI CaesarSaladText;
    public TextMeshProUGUI OmeletteText;
    public TextMeshProUGUI PancakeText;
    public TextMeshProUGUI QuesadillaText;
    public TextMeshProUGUI ScrambledText;
    public TextMeshProUGUI WaffleText;
    public TextMeshProUGUI CoffeeText;
    public TextMeshProUGUI IcedCoffeeText;
    public TextMeshProUGUI ManPeachSmoothieText;
    public TextMeshProUGUI MatchaText;
    public TextMeshProUGUI PineCocoSmoothieText;
    public TextMeshProUGUI StrawBanSmoothieText;
    public TextMeshProUGUI VanFrappeText;




    public Canvas inventoryCanvas;
    public Canvas gachaCanvas;

    public CoinCounter cc;
    public Progression prog;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (prog == null)
        {
            prog = Object.FindAnyObjectByType<Progression>();
        }

        randomSeed = Random.Range(0, 9999);
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
        if (cc != null && prog.coins >= 6)
        {
            RollNumber = GetWeightedRandom();
            StartCoroutine("Rolling");
            prog.coins -= 6;
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
            case 0: RollItem(ref BaconEggCheese, "Bacon Egg & Cheese", BECText, 1);
                prog.hasBaconEggCheese = true;
                break;
            case 1: RollItem(ref Burger, "Burger", BurgerText, 1);
                prog.hasBurger = true;
                break;
            case 2: RollItem(ref CaesarSalad, "Caesar Salad", CaesarSaladText, 2);
                prog.hasCaesarSalad = true;
                break;
            case 3: RollItem(ref Omelette, "Omelette", OmeletteText, 2);
                prog.hasOmelette = true;
                break;
            case 4: RollItem(ref Pancakes, "Pancakes", PancakeText, 2);
                prog.hasPancakes = true;
                break;
            case 5: RollItem(ref Quesadilla, "Quesadilla", QuesadillaText, 2);
                prog.hasQuesadilla = true;
                break;
            case 6: RollItem(ref ScrambledEggs, "Scrambled Eggs", ScrambledText, 2);
                prog.hasScrambledEggs = true;
                break;
            case 7: RollItem(ref Waffles, "Waffles", WaffleText, 3);
                prog.hasWaffles = true;
                break;
            case 8: RollItem(ref Coffee, "Coffee", CoffeeText, 3);
                prog.hasCoffee = true;
                break;
            case 9: RollItem(ref IcedCoffee, "Iced Coffee", IcedCoffeeText, 3);
                prog.hasIcedCoffee = true;
                break;
            case 10: RollItem(ref MangoPeachSmoothie, "Mango Peach Smoothie", ManPeachSmoothieText, 4);
                prog.hasMangoPeachSmoothie = true;
                break;
            case 11: RollItem(ref MatchaLatte, "Matcha Latte", MatchaText, 4);
                prog.hasMatchaLatte = true;
                break;
            case 12: RollItem(ref PineCocoSmoothie, "Pine-Coco Smoothie", PineCocoSmoothieText, 4);
                prog.hasPineCocoSmoothie = true;
                break;
            case 13: RollItem(ref StrawBanSmoothie, "Straw-Ban Smoothie", StrawBanSmoothieText, 5);
                prog.hasStrawBanSmoothie = true;
                break;
            case 14: RollItem(ref VanFrappe, "Vanilla Frappe", VanFrappeText, 6);
                prog.hasVanFrappe = true;
                break;
        }
    }

    private void RollItem(ref int itemCount, string itemName, TextMeshProUGUI itemText, int refundAmount)
    {
        bool alreadyGot = itemCount > 0;
        itemCount++;
        rollText.text = $"{itemName} ({weights[RollNumber]}% chance)";
        itemText.text = itemName;

        if (alreadyGot && cc != null)
        {
            prog.coins += refundAmount;
            rollText.text = $"Already had {itemName}! Refunded {refundAmount} coin(s).";
        }
    }
}
