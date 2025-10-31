using UnityEngine;

public class AssemblyLine : MonoBehaviour
{
    bool Bacon;
    bool Patty;
    bool Bun;
    bool Butter;
    bool Cheese;
    bool Egg;
    bool GreenOnion;
    bool Onion;
    bool Lettuce;
    bool Spinach;
    bool Tomato;
    bool Tortilla;
    bool Croutons;
    bool Milk;
    bool Flour;

    public GameObject BaconEggCheese;
    public GameObject Burger;
    public GameObject CaesarSalad;
    public GameObject Omelette;
    public GameObject Pancakes;
    public GameObject Quesadilla;
    public GameObject ScrambledEggs;
    public GameObject Waffles;


    public Transform foodSpawner;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TryMakeBreakfastQuesadilla();
        TryMakeBaconEggCheese();
        TryMakeCaesarSalad();
        TryMakeCheeseburger();
        TryMakeOmelette();
        TryMakePancakes();
        TryMakeWaffle();
        TryMakeScrambledEggs();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CookedBacon"))
        {
            Bacon = true;
            Debug.Log("Bacon added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("CookedPatty"))
        {
            Patty = true;
            Debug.Log("Patty added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Bun"))
        {
            Bun = true;
            Debug.Log("Bun added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Butter"))
        {
            Butter = true;
            Debug.Log("Butter added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Cheese"))
        {
            Cheese = true;
            Debug.Log("Cheese added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Egg"))
        {
            Egg = true;
            Debug.Log("Egg added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("GreenOnion"))
        {
            GreenOnion = true;
            Debug.Log("Green Onion added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Lettuce"))
        {
            Lettuce = true;
            Debug.Log("Lettuce added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Spinach"))
        {
            Spinach = true;
            Debug.Log("Spinach added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Tomato"))
        {
            Tomato = true;
            Debug.Log("Tomato added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Tortilla"))
        {
            Tortilla = true;
            Debug.Log("Tortilla added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Croutons"))
        {
            Croutons = true;
            Debug.Log("Tortilla added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Onion"))
        {
            Onion = true;
            Debug.Log("Onion added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Milk"))
        {
            Milk = true;
            Debug.Log("Milk added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Flour"))
        {
            Flour = true;
            Debug.Log("Flour added!");
            Destroy(collision.gameObject);
        }

    }

    private void TryMakeCheeseburger()
    {
        if (Lettuce && Tomato && Onion && Patty && Bun)
        {
            Debug.Log("Made a Cheeseburger");
            Instantiate(Burger, foodSpawner.position, Quaternion.identity);
            Lettuce = false;
            Tomato = false;
            GreenOnion = false;
            Patty = false;
            Bun = false;
        }
    }

    private void TryMakeBaconEggCheese()
    {
        if (Bacon && Egg && Cheese)
        {
            Debug.Log("Made a Bacon Egg and Cheese");
            Instantiate(BaconEggCheese, foodSpawner.position, Quaternion.identity);
            Bacon = false;
            Egg = false;
            Cheese = false;
        }
    }

    private void TryMakeBreakfastQuesadilla()
    {
        if (Bacon && Egg && Cheese)
        {
            Debug.Log("Made a Bacon Egg and Cheese");
            Instantiate(Quesadilla, foodSpawner.position, Quaternion.identity);
            Bacon = false;
            Egg = false;
            Cheese = false;
        }
    }
    private void TryMakeScrambledEggs()
    {
        if (Butter && Egg && GreenOnion)
        {
            Debug.Log("Made Scrambled Eggs");
            Instantiate(ScrambledEggs, foodSpawner.position, Quaternion.identity);
            Butter = false;
            Egg = false;
            GreenOnion = false;
        }
    }
    private void TryMakeCaesarSalad()
    {
        if (Lettuce && Cheese && Croutons)
        {
            Debug.Log("Made a Caesar Salad");
            Instantiate(CaesarSalad, foodSpawner.position, Quaternion.identity);
            Lettuce = false;
            Cheese = false;
            Croutons = false;
        }
    }
    private void TryMakeOmelette()
    {
        if (Spinach && Cheese && Egg && GreenOnion)
        {
            Debug.Log("Made a Spinach and Cheese Omelette");
            Instantiate(Omelette, foodSpawner.position, Quaternion.identity);
            Spinach = false;
            Cheese = false;
            Egg = false;
        }
    }
    private void TryMakePancakes()
    {
        if (Egg && Milk && Flour && Butter)
        {
            Debug.Log("Made a Pancake");
            Instantiate(Pancakes, foodSpawner.position, Quaternion.identity);
            Egg = false;
            Milk = false;
            Flour = false;
            Butter = false;
        }
    }
    private void TryMakeWaffle()
    {
        if (Egg && Milk && Flour)
        {
            Debug.Log("Made a Waffle");
            Instantiate(Waffles, foodSpawner.position, Quaternion.identity);
            Egg = false;
            Milk = false;
            Flour = false;
        }
    }
}
