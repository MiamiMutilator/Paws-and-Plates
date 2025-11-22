using UnityEngine;
using UnityEngine.SceneManagement;

public class CoffeeMachine : MonoBehaviour
{
    bool Milk;
    bool CoffeeBean;
    bool Ice;

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

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Milk"))
        {
            Milk = true;
            Debug.Log("Milk added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("CoffeeBean"))
        {
            CoffeeBean = true;
            Debug.Log("Coffee Beans added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Ice"))
        {
            Ice = true;
            Debug.Log("Ice added!");
            Destroy(collision.gameObject);
        }

    }


    private bool TryMakeIcedCoffee()
    {
        if (CoffeeBean && Milk && Ice)
        {
            Debug.Log("Made a Strawberry Banana Smoothie");
            Instantiate(IcedCoffee, foodSpawner.position, Quaternion.identity);
            CoffeeBean = false;
            Milk = false;
            Ice = false;
            return true;
        }
        return false;

    }

    private void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void blend()
    {
        //TryMakeCoffee();
        if (TryMakeIcedCoffee()) return;
    }

    public void discard()
    {
        CoffeeBean = false;
        Ice = false;
        Milk = false;
    }
}
