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
        // Load any saved unlocks from PlayerPrefs so progression state persists between sessions
        LoadSavedUnlocks();
    }

    private void LoadSavedUnlocks()
    {
        hasBaconEggCheese = PlayerPrefs.GetInt("BaconEggCheese", hasBaconEggCheese ? 1 : 0) == 1;
        hasBurger = PlayerPrefs.GetInt("Burger", hasBurger ? 1 : 0) == 1;
        hasCaesarSalad = PlayerPrefs.GetInt("CaesarSalad", hasCaesarSalad ? 1 : 0) == 1;
        hasOmelette = PlayerPrefs.GetInt("Omelette", hasOmelette ? 1 : 0) == 1;
        hasPancakes = PlayerPrefs.GetInt("Pancakes", hasPancakes ? 1 : 0) == 1;
        hasQuesadilla = PlayerPrefs.GetInt("Quesadilla", hasQuesadilla ? 1 : 0) == 1;
        hasScrambledEggs = PlayerPrefs.GetInt("ScrambledEggs", hasScrambledEggs ? 1 : 0) == 1;
        hasWaffles = PlayerPrefs.GetInt("Waffles", hasWaffles ? 1 : 0) == 1;
        hasCoffee = PlayerPrefs.GetInt("Coffee", hasCoffee ? 1 : 0) == 1;
        hasIcedCoffee = PlayerPrefs.GetInt("IcedCoffee", hasIcedCoffee ? 1 : 0) == 1;
        hasMangoPeachSmoothie = PlayerPrefs.GetInt("MangoPeachSmoothie", hasMangoPeachSmoothie ? 1 : 0) == 1;
        hasMatchaLatte = PlayerPrefs.GetInt("MatchaLatte", hasMatchaLatte ? 1 : 0) == 1;
        hasPineCocoSmoothie = PlayerPrefs.GetInt("PineCocoSmoothie", hasPineCocoSmoothie ? 1 : 0) == 1;
        hasStrawBanSmoothie = PlayerPrefs.GetInt("StrawBanSmoothie", hasStrawBanSmoothie ? 1 : 0) == 1;
        hasVanFrappe = PlayerPrefs.GetInt("VanFrappe", hasVanFrappe ? 1 : 0) == 1;
        hasFruitYogurt = PlayerPrefs.GetInt("FruitYogurt", hasFruitYogurt ? 1 : 0) == 1;
    }

    // Public helper to unlock an item and persist it
    public void Unlock(GachaItemDisplay.FoodType type)
    {
        // Map types to progression flags and persist
        switch (type)
        {
            case GachaItemDisplay.FoodType.BaconEggCheese: hasBaconEggCheese = true; PlayerPrefs.SetInt("BaconEggCheese", 1); break;
            case GachaItemDisplay.FoodType.Burger: hasBurger = true; PlayerPrefs.SetInt("Burger", 1); break;
            case GachaItemDisplay.FoodType.CaesarSalad: hasCaesarSalad = true; PlayerPrefs.SetInt("CaesarSalad", 1); break;
            case GachaItemDisplay.FoodType.Omelette: hasOmelette = true; PlayerPrefs.SetInt("Omelette", 1); break;
            case GachaItemDisplay.FoodType.Pancakes: hasPancakes = true; PlayerPrefs.SetInt("Pancakes", 1); break;
            case GachaItemDisplay.FoodType.Quesadilla: hasQuesadilla = true; PlayerPrefs.SetInt("Quesadilla", 1); break;
            case GachaItemDisplay.FoodType.ScrambledEggs: hasScrambledEggs = true; PlayerPrefs.SetInt("ScrambledEggs", 1); break;
            case GachaItemDisplay.FoodType.Waffles: hasWaffles = true; PlayerPrefs.SetInt("Waffles", 1); break;
            case GachaItemDisplay.FoodType.Coffee: hasCoffee = true; PlayerPrefs.SetInt("Coffee", 1); break;
            case GachaItemDisplay.FoodType.IcedCoffee: hasIcedCoffee = true; PlayerPrefs.SetInt("IcedCoffee", 1); break;
            case GachaItemDisplay.FoodType.MangoPeachSmoothie: hasMangoPeachSmoothie = true; PlayerPrefs.SetInt("MangoPeachSmoothie", 1); break;
            case GachaItemDisplay.FoodType.MatchaLatte: hasMatchaLatte = true; PlayerPrefs.SetInt("MatchaLatte", 1); break;
            case GachaItemDisplay.FoodType.PineCocoSmoothie: hasPineCocoSmoothie = true; PlayerPrefs.SetInt("PineCocoSmoothie", 1); break;
            case GachaItemDisplay.FoodType.StrawBanSmoothie: hasStrawBanSmoothie = true; PlayerPrefs.SetInt("StrawBanSmoothie", 1); break;
            case GachaItemDisplay.FoodType.VanFrappe: hasVanFrappe = true; PlayerPrefs.SetInt("VanFrappe", 1); break;
            case GachaItemDisplay.FoodType.FruitYogurt: hasFruitYogurt = true; PlayerPrefs.SetInt("FruitYogurt", 1); break;
        }
        PlayerPrefs.Save();
        Debug.Log($"Progression: unlocked {type}");
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
