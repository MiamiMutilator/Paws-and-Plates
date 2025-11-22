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
    bool Yogurt;
    bool StrawBerry;

    public GameObject BaconEggCheese;
    public GameObject Burger;
    public GameObject CaesarSalad;
    public GameObject Omelette;
    public GameObject Pancakes;
    public GameObject Quesadilla;
    public GameObject ScrambledEggs;
    public GameObject Waffles;
    public GameObject FruitYogurt;

    public Transform foodSpawner;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TryMakeBreakfastQuesadilla()) return;
        if (TryMakeBaconEggCheese()) return;
        if (TryMakeCaesarSalad()) return;
        if (TryMakeCheeseburger()) return;
        if (TryMakeOmelette()) return;
        if (TryMakePancakes()) return;
        if (TryMakeWaffle()) return;
        if (TryMakeScrambledEggs()) return;
        if (TryMakeFruitYogurt()) return;
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
        if (collision.CompareTag("Yogurt"))
        {
            Yogurt = true;
            Debug.Log("Yogurt added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Strawberry"))
        {
            StrawBerry = true;
            Debug.Log("Strawberry added!");
            Destroy(collision.gameObject);
        }



    }

    private bool TryMakeCheeseburger()
    {
        if (Lettuce && Cheese && Tomato && Onion && Patty && Bun)
        {
            Debug.Log("Made a Cheeseburger");
            Instantiate(Burger, foodSpawner.position, Quaternion.identity);
            Lettuce = false;
            Tomato = false;
            GreenOnion = false;
            Patty = false;
            Bun = false;
            Cheese = false;
            return true;
        }
        return false;
    }

    private bool TryMakeBaconEggCheese()
    {
        if (Bacon && Egg && Cheese)
        {
            Debug.Log("Made a Bacon Egg and Cheese");
            Instantiate(BaconEggCheese, foodSpawner.position, Quaternion.identity);
            Bacon = false;
            Egg = false;
            Cheese = false;
            return true;
        }
        return false;
    }

    private bool TryMakeBreakfastQuesadilla()
    {
        if (Bacon && Egg && Cheese && Tortilla)
        {
            Debug.Log("Made a Bacon Egg and Cheese");
            Instantiate(Quesadilla, foodSpawner.position, Quaternion.identity);
            Tortilla = false;
            Bacon = false;
            Egg = false;
            Cheese = false;
            return true;
        }
        return false;
    }
    private bool TryMakeScrambledEggs()
    {
        if (Butter && Egg && GreenOnion)
        {
            Debug.Log("Made Scrambled Eggs");
            Instantiate(ScrambledEggs, foodSpawner.position, Quaternion.identity);
            Butter = false;
            Egg = false;
            GreenOnion = false;
            return true;
        }
        return false;
    }
    private bool TryMakeCaesarSalad()
    {
        if (Lettuce && Cheese && Croutons)
        {
            Debug.Log("Made a Caesar Salad");
            Instantiate(CaesarSalad, foodSpawner.position, Quaternion.identity);
            Lettuce = false;
            Cheese = false;
            Croutons = false;
            return true;
        }
        return false;
    }
    private bool TryMakeOmelette()
    {
        if (Spinach && Cheese && Egg && GreenOnion)
        {
            Debug.Log("Made a Spinach and Cheese Omelette");
            Instantiate(Omelette, foodSpawner.position, Quaternion.identity);
            Spinach = false;
            Cheese = false;
            Egg = false;
            return true;
        }
        return false;
    }
    private bool TryMakePancakes()
    {
        if (Egg && Milk && Flour && Butter)
        {
            Debug.Log("Made a Pancake");
            Instantiate(Pancakes, foodSpawner.position, Quaternion.identity);
            Egg = false;
            Milk = false;
            Flour = false;
            Butter = false;
            return true;
        }
        return false;
    }
    private bool TryMakeWaffle()
    {
        if (Egg && Milk && Flour)
        {
            Debug.Log("Made a Waffle");
            Instantiate(Waffles, foodSpawner.position, Quaternion.identity);
            Egg = false;
            Milk = false;
            Flour = false;
            return true;
        }
        return false;
    }
    private bool TryMakeFruitYogurt()
    {
        if (Yogurt && StrawBerry)
        {
            Debug.Log("Made Fruit Yogurt");
            Instantiate(FruitYogurt, foodSpawner.position, Quaternion.identity);
            Yogurt = false;
            StrawBerry = false;
            return true;
        }
        return false;
    }

}
