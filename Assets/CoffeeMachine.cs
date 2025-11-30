using UnityEngine;
using UnityEngine.SceneManagement;

public class CoffeeMachine : MonoBehaviour
{
    bool Milk;
    bool CoffeeBean;
    bool Ice;
    bool espressoDrink;
    bool Vanilla;

    public GameObject IcedCoffee;
    public GameObject Coffee;
    public GameObject VanillaFrappuccino;


    public Transform foodSpawner;

    public InventoryUi inventoryUi;
    public GameObject espresso;


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
        TryMakeVanillaFrap();
        TryMakeIcedCoffee();
        TryMakeCoffee();
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
            Destroy(collision.gameObject);
            spawnEspresso();
        }
        if (collision.CompareTag("Ice"))
        {
            Ice = true;
            Debug.Log("Ice added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Espresso"))
        {
            espressoDrink = true;
            Debug.Log("Espresso added!");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Vanilla"))
        {
            Vanilla = true;
            Debug.Log("Vanilla added!");
            Destroy(collision.gameObject);
        }


    }


    private bool TryMakeIcedCoffee()
    {
        if (espressoDrink && Milk && Ice)
        {
            Debug.Log("Made an Iced Coffee");
            Instantiate(IcedCoffee, foodSpawner.position, Quaternion.identity);
            espressoDrink = false;
            Milk = false;
            Ice = false;
            return true;
        }
        return false;

    }
    private bool TryMakeCoffee()
    {
        if (espressoDrink && Milk)
        {
            Debug.Log("Made Coffee");
            Instantiate(Coffee, foodSpawner.position, Quaternion.identity);
            espressoDrink = false;
            Milk = false;
            return true;
        }
        return false;

    }
    private bool TryMakeVanillaFrap()
    {
        if (espressoDrink && Milk && Vanilla)
        {
            Debug.Log("Made Vanilla Frappuccino");
            Instantiate(VanillaFrappuccino, foodSpawner.position, Quaternion.identity);
            espressoDrink = false;
            Milk = false;
            Vanilla = false;
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

    public void spawnEspresso()
    {
        foreach (SlotUi slot in inventoryUi.slots)
        {
            bool isEmpty = slot.itemIcon.sprite == null && slot.transform.childCount <= 1;

            if (isEmpty)
            {
                GameObject spawned = Instantiate(espresso, slot.transform);
                RectTransform rt = spawned.GetComponent<RectTransform>();

                rt.anchorMin = new Vector2(0.5f, 0.5f);
                rt.anchorMax = new Vector2(0.5f, 0.5f);
                rt.pivot = new Vector2(0.5f, 0.5f);
                rt.anchoredPosition = Vector2.zero;

                Vector3 parentScale = slot.transform.lossyScale;
                spawned.transform.localScale = new Vector3(
                    0.05f / parentScale.x,
                    0.05f / parentScale.y,
                    1f / parentScale.z
                );

                return;
            }
        }
    }
}
