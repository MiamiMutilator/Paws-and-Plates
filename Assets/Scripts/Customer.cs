using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class Customer : MonoBehaviour
{
    public int randomSeed;
    public int typeOfCustomer;
    public int customerPatience = 60;
    public int dialogueNum;
    public string customersFood;

    public TextMeshProUGUI customerOrder;

    public Progression prog;

    private Dictionary<int, string[]> customerDialogues = new Dictionary<int, string[]>();

    private void Awake()
    {
        customerDialogues[0] = new string[]
        {
            "I'm so hungry I could eat a horse, hooves and all.",
            "You know what, surprise me!",
            "I’ll try anything once!"
        };

        customerDialogues[1] = new string[]
        {
            "Hmm, I want a sweet drink with strawberry!"
        };

        customerDialogues[2] = new string[]
        {
            "Mangoes! Peaches! Smoothie!"
        };

        customerDialogues[3] = new string[]
        {
            "One iced coffee please!"
        };

        customerDialogues[4] = new string[]
        {
            "I want something smooth with matcha."
        };

        customerDialogues[5] = new string[]
        {
            "I, like, want a vanilla frap!"
        };

        customerDialogues[6] = new string[]
        {
            "Do you like piña colladas?"
        };

        customerDialogues[7] = new string[]
        {
            "I need a pick-me-up drink..."
        };
        customerDialogues[8] = new string[]
        {
            "One cheeseburger please!"
        };
        customerDialogues[9] = new string[]
        {
            "Please get me something with Bacon, Egg, and Cheese!"
        };
        customerDialogues[10] = new string[]
        {
            "I'm in the mood for a latin breakfast."
        };
        customerDialogues[11] = new string[]
        {
            "You know Scrambled Studios? They're cool!"
        };
        customerDialogues[12] = new string[]
        {
            "Et tu, Bruté?"
        };
        customerDialogues[13] = new string[]
        {
            "I want a relatively balanced breakfast."
        };
        customerDialogues[14] = new string[]
        {
            "I HATE waffles."
        };
        customerDialogues[15] = new string[]
        {
            "I HATE pancakes."
        };
    }

    private void Start()
    {
        prog = Progression.Instance;

        List<string> unlockedFoods = new List<string>();

        if (prog.hasBaconEggCheese) unlockedFoods.Add("BaconEggCheese");
        if (prog.hasBurger) unlockedFoods.Add("Burger");
        if (prog.hasCaesarSalad) unlockedFoods.Add("Salad");
        if (prog.hasOmelette) unlockedFoods.Add("Omelette");
        if (prog.hasPancakes) unlockedFoods.Add("Pancakes");
        if (prog.hasQuesadilla) unlockedFoods.Add("Quesadilla");
        if (prog.hasScrambledEggs) unlockedFoods.Add("ScrambledEggs");
        if (prog.hasWaffles) unlockedFoods.Add("Waffles");
        if (prog.hasCoffee) unlockedFoods.Add("Coffee");
        if (prog.hasIcedCoffee) unlockedFoods.Add("IceCoffee");
        if (prog.hasMangoPeachSmoothie) unlockedFoods.Add("ManPeachSmoothie");
        if (prog.hasMatchaLatte) unlockedFoods.Add("MatchaLatte");
        if (prog.hasPineCocoSmoothie) unlockedFoods.Add("PineCocoSmoothie");
        if (prog.hasStrawBanSmoothie) unlockedFoods.Add("StrawBanSmoothie");
        if (prog.hasVanFrappe) unlockedFoods.Add("VanFrappe");
        unlockedFoods.Add("Untagged");

        int randomFood = Random.Range(0, unlockedFoods.Count);
        customersFood = unlockedFoods[randomFood];
        switch (customersFood)
        {
            case "Untagged":
                typeOfCustomer = 0;
                break;
            case "StrawBanSmoothie":
                typeOfCustomer = 1;
                break;
            case "ManPeachSmoothie":
                typeOfCustomer = 2;
                break;
            case "IceCoffee":
                typeOfCustomer = 3;
                break;
            case "MatchaLatte":
                typeOfCustomer = 4;
                break;
            case "VanFrappe":
                typeOfCustomer = 5;
                break;
            case "PineCocoSmoothie":
                typeOfCustomer = 6;
                break;
            case "Coffee":
                typeOfCustomer = 7;
                break;
            case "Burger":
                typeOfCustomer = 8;
                break;
            case "BaconEggCheese":
                typeOfCustomer = 9;
                break;
            case "Quesadilla":
                typeOfCustomer = 10;
                break;
            case "ScrambledEggs":
                typeOfCustomer = 11;
                break;
            case "Salad":
                typeOfCustomer = 12;
                break;
            case "Omelette":
                typeOfCustomer = 13;
                break;
            case "Pancakes":
                typeOfCustomer = 14;
                break;
            case "Waffles":
                typeOfCustomer = 15;
                break;
            default:
                customersFood = "Untagged";
                break;
        }
        customerBehavior();
    }

    private void Update()
    {
        
        if (customerPatience == 0)
        {
            Debug.Log("I'm leaving!");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(customersFood) || typeOfCustomer == 0)
        {
            customerOrder.text = "Yum!";
            Debug.Log("Yum!");
            prog.coins += 25;
            Destroy(collision.gameObject);
        }
        else
        {
            customerOrder.text = "I don't want this!";
            Debug.Log("I don't want this!");
        }
    }

    private void customerBehavior()
    {
        StartCoroutine(patienceTimer());

        if (customerDialogues.ContainsKey(typeOfCustomer))
        {
            string[] lines = customerDialogues[typeOfCustomer];
            int randomIndex = Random.Range(0, lines.Length);
            Debug.Log(lines[randomIndex]);
            customerOrder.text = (lines[randomIndex]);
        }
    }

    private IEnumerator patienceTimer()
    {
        customerPatience = 60;
        while (customerPatience >= 0)
        {
            customerPatience--;
            yield return new WaitForSeconds(1);
        }
    }

}
