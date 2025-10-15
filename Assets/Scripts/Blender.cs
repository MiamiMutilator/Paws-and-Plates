using UnityEngine;
using UnityEngine.SceneManagement;


public class Blender : MonoBehaviour
{
    bool Banana;
    bool Coconut;
    bool coffeeBean;
    bool Ice;
    bool Mango;
    bool Matcha;
    bool Milk;
    bool Peach;
    bool Pineapple;
    bool Strawberry;
    bool Vanilla;

    public GameObject StrawberryBananaSmoothie;
    public GameObject IcedMatchaLatte;
    public GameObject Coffee;
    public GameObject MangoPeachSmoothie;
    public GameObject VanillaFrappucino;
    public GameObject PineappleCoconutSmoothie;
    public GameObject IcedCoffee;





    public Transform foodSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            restartScene();
        }
        //TryMakeCoffee();
        TryMakeIcedMatchaLatte();
        TryMakeIcedCoffee();
        TryMakeManPeachSmoothie();
        TryMakePineCocoSmoothie();
        TryMakeStrawBanSmoothie();
        TryMakeVanillaFrappe();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Banana"))
        {
            Banana = true;
            Debug.Log("Banana added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Coconut"))
        {
            Coconut = true;
            Debug.Log("Coconut added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("CoffeeBean"))
        {
            coffeeBean = true;
            Debug.Log("CoffeeBean added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Ice"))
        {
            Ice = true;
            Debug.Log("Ice added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Mango"))
        {
            Mango = true;
            Debug.Log("Mango added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Matcha"))
        {
            Matcha = true;
            Debug.Log("Matcha added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Milk"))
        {
            Milk = true;
            Debug.Log("Milk added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Peach"))
        {
            Peach = true;
            Debug.Log("Peach added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Pineapple"))
        {
            Pineapple = true;
            Debug.Log("Pineapple added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Strawberry"))
        {
            Strawberry = true;
            Debug.Log("Strawberry added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Vanilla"))
        {
            Vanilla = true;
            Debug.Log("Vanilla added!");
            Destroy(collision.gameObject);
        }
    }


    private void TryMakeStrawBanSmoothie()
    {
        if (Strawberry && Banana && Milk && Ice)
        {
            Debug.Log("Made a Strawberry Banana Smoothie");
            Instantiate(StrawberryBananaSmoothie, foodSpawner.position, Quaternion.identity);
            Strawberry = false;
            Banana = false;
            Milk = false;
            Ice = false;

        }
    }
    private void TryMakeIcedMatchaLatte()
    {
        if (Milk && Matcha && Coffee && Ice)
        {
            Debug.Log("Made an Iced Matcha Latte");
            Instantiate(IcedMatchaLatte, foodSpawner.position, Quaternion.identity);
            Milk = false;
            Matcha = false;
            coffeeBean = false;
            Ice = false;
        }
    }

    private void TryMakeCoffee()
    {
        if (Milk && coffeeBean)
        {
            Debug.Log("Made Coffee!");
            Instantiate(Coffee, foodSpawner.position, Quaternion.identity);
            Milk = false;
            coffeeBean = false;
        }
    }

    private void TryMakeManPeachSmoothie()
    {
        if (Mango && Peach && Milk)
        {
            Debug.Log("Made a Mango Peach Smoothie");
            Instantiate(MangoPeachSmoothie, foodSpawner.position, Quaternion.identity);
            Milk = false;
            Peach = false;
            Mango = false;
        }
    }

    private void TryMakeVanillaFrappe()
    {
        if (Vanilla && Milk && Coffee)
        {
            Debug.Log("Made a Vanillea Frappe");
            Instantiate(VanillaFrappucino, foodSpawner.position, Quaternion.identity);
            Strawberry = false;
            Vanilla = false;
            Milk = false;
            coffeeBean = false;
        }
    }
    private void TryMakePineCocoSmoothie()
    {
        if (Coconut && Pineapple && Milk)
        {
            Debug.Log("Made a Pineapple Coco Smoothie");
            Instantiate(PineappleCoconutSmoothie, foodSpawner.position, Quaternion.identity);
            Coconut = false;
            Pineapple = false;
            Milk = false;
        }
    }
    private void TryMakeIcedCoffee()
    {
        if (coffeeBean && Milk && Ice)
        {
            Debug.Log("Made an Iced Coffee");
            Instantiate(IcedCoffee, foodSpawner.position, Quaternion.identity);
            coffeeBean = false;
            Milk = false;
            Ice = false;

        }
    }

    private void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
