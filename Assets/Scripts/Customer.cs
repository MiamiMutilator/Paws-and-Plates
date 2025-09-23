using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class Customer : MonoBehaviour
{
    public int randomSeed;
    public int typeOfCustomer;
    public int customerPatience = 60;
    public int dialogueNum;

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
            "I want a pizza!",
            "Got any pizza for me?",
            "Pizza sounds perfect right now."
        };

        customerDialogues[2] = new string[]
        {
            "I want a burger!",
            "A burger would hit the spot!",
            "Got any burgers around here?",
            "Give me a nice juicy burger, please!"
        };

        customerDialogues[3] = new string[]
        {
            "I want a Coffee!",
            "Can I get a coffee, please?",
            "I need some caffeine!"
        };

        customerDialogues[4] = new string[]
        {
            "I want a Donut!",
            "Donut me up!",
            "Got any donuts?"
        };

        customerDialogues[5] = new string[]
        {
            "I want a Latte!",
            "Latte, please!",
            "I need something fancy – a latte!"
        };
    }

    private void Start()
    {
        randomSeed = Random.Range(0, 15);
        Random.InitState(randomSeed);
        typeOfCustomer = Random.Range(0, 6); // fixed max so type 5 is possible
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
        if (collision.gameObject.CompareTag("Meat Food"))
        {
            switch (typeOfCustomer)
            {
                case 0:
                case 2:
                    customerOrder.text = "Yum!";
                    Debug.Log("Yum!");
                    Destroy(collision.gameObject);
                    break;
                default:
                    customerOrder.text = "I don't want this!";
                    Debug.Log("I don't want this!");
                    break;
            }
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
