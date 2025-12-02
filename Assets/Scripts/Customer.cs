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
    public GameObject chatBubble;

    public TextMeshProUGUI customerOrder;

    public Progression prog;

    //customer movement
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    private int waypointIndex = 0;
    private Coroutine patienceCoroutine;


    [SerializeField] Sprite[] arraySprites;
    [SerializeField] Sprite newSprite;
    public SpriteRenderer customerEmotion;

    //track if customer is at last way point
    private bool hasArrivedAtService = false; 

    private Dictionary<int, string[]> customerDialogues = new Dictionary<int, string[]>();

    private void Awake()
    {
        customerDialogues[0] = new string[]
        {
            "Give me your best dish!",
            "You know what, surprise me!",
            "I'll try anything once!"
        };

        customerDialogues[1] = new string[]
        {
            "Hmm... A sweet drink with Strawberry!"
        };

        customerDialogues[2] = new string[]
        {
            "Mangoes! Peaches! Smoothie!"
        };

        customerDialogues[3] = new string[]
        {
            "One Iced Coffee please!"
        };

        customerDialogues[4] = new string[]
        {
            "I want something smooth with Matcha."
        };

        customerDialogues[5] = new string[]
        {
            "I, like, want a Vanilla Frap!"
        };

        customerDialogues[6] = new string[]
        {
            "Do you like Pina Coladas?"
        };

        customerDialogues[7] = new string[]
        {
            "One shot of espresso, please!"
        };
        customerDialogues[8] = new string[]
        {
            "One delicious Chezborgir please!"
        };
        customerDialogues[9] = new string[]
        {
            "I'm in dire need of a breakfast sandwich."
        };
        customerDialogues[10] = new string[]
        {
            "I'm in the mood for a quesadilla."
        };
        customerDialogues[11] = new string[]
        {
            "You know Scrambled Studios? Cool!"
        };
        customerDialogues[12] = new string[]
        {
            "I want something healthy, like a salad."
        };
        customerDialogues[13] = new string[]
        {
            "Got any fancy egg dishes?"
        };
        customerDialogues[14] = new string[]
        {
            "I HATE Waffles."
        };
        customerDialogues[15] = new string[]
        {
            "I HATE Pancakes."
        };
        customerDialogues[16] = new string[]
        {
            "I want something with fruit and yogurt."
        };
    }

    private void Start()
    {
        if (prog == null)
        {
            prog = Object.FindAnyObjectByType<Progression>();
        }

        if (chatBubble != null)
            chatBubble.SetActive(false);

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
        if (prog.hasFruitYogurt) unlockedFoods.Add("FruitYogurt");
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
            case "FruitYogurt":
                typeOfCustomer = 16;
                break;
            default:
                customersFood = "Untagged";
                break;
        }
 
    }

    private void Update()
    {
        Move();
    }

    private void Move() //moves the customer
    {
        if (waypoints == null || waypoints.Length == 0)
            return;

        Transform target = waypoints[waypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.01f)
        {
            if (waypointIndex == waypoints.Length - 1) //show chat bubble at final waypoint
            {
                if (!hasArrivedAtService) // only activate bubble and run arrival behavior once
                {
                    if (chatBubble != null)
                        chatBubble.SetActive(true);
                    customerBehavior();
                    hasArrivedAtService = true;
                }
                // keep at last index so customer stays at the service point
            }
            else
            {
                // move to next waypoint 
                waypointIndex += 1;
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Customer")) //so customer colliders aren't misread as food colliders
            return;

        if (collision.gameObject.CompareTag(customersFood) || typeOfCustomer == 0)
        {
            customerOrder.text = "Yum!";
            Debug.Log("Yum!");
            newSprite = arraySprites[1];
            customerEmotion.sprite = newSprite;
            prog.coins += (customerPatience / 2);
            Destroy(collision.gameObject);
            if (patienceCoroutine != null)
            {
                StopCoroutine(patienceCoroutine);
                patienceCoroutine = null;
            }
            // wait 4 seconds before destroying the customer
            StartCoroutine(DestroyAfterDelay(4f));

        }
        else
        {
            customerOrder.text = "I don't want this!";
            Debug.Log("I don't want this!");
        }
    }

    public void OnTriggerStay2D(Collider2D collision) //stops if there's a customer in front of them 
    {
        if (collision.gameObject.CompareTag("Customer"))
        {
            moveSpeed = 0f;
        }
        return;
    }

    private void OnTriggerExit2D(Collider2D collision) //will keep walking if no customer is infront pf them
    {
        if (collision.gameObject.CompareTag("Customer"))
        {
            moveSpeed = 2f;
        }
        return;
    }


    private void customerBehavior()
    {
        if (patienceCoroutine == null)
            patienceCoroutine = StartCoroutine(patienceTimer());

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

        patienceCoroutine = null;
        Leave();
    }


    private void Leave()
    {

        customerOrder.text = "I'm leaving!";
        Debug.Log("I'm leaving!");
        StartCoroutine(DestroyAfterDelay(4f));
        newSprite = arraySprites[0];
        customerEmotion.sprite = newSprite;

    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }


}
