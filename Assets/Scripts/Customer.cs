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
        //randomSeed = Random.Range(0, 15);
        //Random.InitState(randomSeed);
        typeOfCustomer = Random.Range(0, 16); 
        switch (typeOfCustomer)
        {
            case 1:
                customersFood = "StrawBanSmoothie";
                break;
            case 2:
                customersFood = "ManPeachSmoothie";
                break;
            case 3:
                customersFood = "IceCoffee";
                break;
            case 4:
                customersFood = "MatchaLatte";
                break;
            case 5:
                customersFood = "VanFrappe";
                break;
            case 6:
                customersFood = "PineCocoSmoothie";
                    break;
            case 7:
                customersFood = "Coffee";
                break;
            case 8:
                customersFood = "Burger";
                break;
            case 9:
                customersFood = "BaconEggCheese";
                break;
            case 10:
                customersFood = "Quesadilla";
                break;
            case 11:
                customersFood = "ScrambledEggs";
                break;
            case 12:
                customersFood = "Salad";
                break;
            case 13:
                customersFood = "Omelette";
                break;
            case 14:
                customersFood = "Pancakes";
                break;
            case 15:
                customersFood = "Waffles";
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
            StopCoroutine(patienceTimer());
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
        while (customerPatience >= 0)
        {
            customerPatience--;
            yield return new WaitForSeconds(1);
        }
    }

}
