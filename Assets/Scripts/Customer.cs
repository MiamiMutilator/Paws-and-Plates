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
            "I'll eat anything!",
            "Surprise me with some food!",
            "I’m not picky, bring me whatever!"
        };

        customerDialogues[1] = new string[]
        {
            "I want a Strawberry Banana Smoothie!"
        };

        customerDialogues[2] = new string[]
        {
            "I want a Mango Peach Smoothie!"
        };

        customerDialogues[3] = new string[]
        {
            "I want an Iced Coffee!"
        };

        customerDialogues[4] = new string[]
        {
            "I want a Matcha Latte!"
        };

        customerDialogues[5] = new string[]
        {
            "I want a Vanilla Frappe!"
        };

        customerDialogues[6] = new string[]
        {
            "I want a Pineapple Coconut Smoothie!"
        };
    }

    private void Start()
    {
        //randomSeed = Random.Range(0, 15);
        //Random.InitState(randomSeed);
        typeOfCustomer = Random.Range(0, 7); 
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
