using UnityEngine;

public class Progression : MonoBehaviour
{
    public static Progression Instance;

    public int coins = 10;

    public bool hasBaconEggCheese;
    public bool hasBurger;
    public bool hasCaesarSalad;
    public bool hasOmelette;
    public bool hasPancakes;
    public bool hasQuesadilla;
    public bool hasScrambledEggs;
    public bool hasWaffles;
    public bool hasCoffee;
    public bool hasIcedCoffee;
    public bool hasMangoPeachSmoothie;
    public bool hasMatchaLatte;
    public bool hasPineCocoSmoothie;
    public bool hasStrawBanSmoothie;
    public bool hasVanFrappe;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GainCurrency();
        }
    }

    void GainCurrency()
    {
        coins += 5;
    }
}
