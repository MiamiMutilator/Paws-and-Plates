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
    public bool hasFruitYogurt;
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

    public bool IsUnlocked(GachaItemDisplay.FoodType type)
    {
        return type switch
        {
            GachaItemDisplay.FoodType.BaconEggCheese => hasBaconEggCheese,
            GachaItemDisplay.FoodType.Burger => hasBurger,
            GachaItemDisplay.FoodType.CaesarSalad => hasCaesarSalad,
            GachaItemDisplay.FoodType.Omelette => hasOmelette,
            GachaItemDisplay.FoodType.Pancakes => hasPancakes,
            GachaItemDisplay.FoodType.Quesadilla => hasQuesadilla,
            GachaItemDisplay.FoodType.ScrambledEggs => hasScrambledEggs,
            GachaItemDisplay.FoodType.Waffles => hasWaffles,
            GachaItemDisplay.FoodType.Coffee => hasCoffee,
            GachaItemDisplay.FoodType.IcedCoffee => hasIcedCoffee,
            GachaItemDisplay.FoodType.MangoPeachSmoothie => hasMangoPeachSmoothie,
            GachaItemDisplay.FoodType.MatchaLatte => hasMatchaLatte,
            GachaItemDisplay.FoodType.PineCocoSmoothie => hasPineCocoSmoothie,
            GachaItemDisplay.FoodType.StrawBanSmoothie => hasStrawBanSmoothie,
            GachaItemDisplay.FoodType.VanFrappe => hasVanFrappe,
            GachaItemDisplay.FoodType.FruitYogurt => hasFruitYogurt,
            _ => false
        };
    }
}
