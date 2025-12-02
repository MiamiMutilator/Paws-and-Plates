using UnityEngine;
using TMPro; // Needed for TextMeshPro

public class GachaItemDisplay : MonoBehaviour
{
    [Header("The Data")]
    public GachaItemData itemData;
    public FoodType foodType;

    [Header("Visual Components")]
    // CHANGED: Now looks for a SpriteRenderer instead of an Image
    [SerializeField] private SpriteRenderer foodIconRenderer; 
    
    // CHANGED: TMP_Text works for both UI Text and World Text
    [SerializeField] private TMP_Text chanceText;

    // This defines your specific Grey color (#555555)
    private Color lockedColor = new Color(0.33f, 0.33f, 0.33f, 1f); 
    private Color unlockedColor = Color.white;

    [Header("Sizing")]
    [Tooltip("When true, the unlocked sprite will be scaled to match the size of the existing icon so it replaces the locked graphic cleanly.")]
    [SerializeField] private bool autoMatchIconSize = true;

    // captured baseline size (in world units) based on the initial sprite and scale
    private Vector2 targetSpriteWorldSize = Vector2.zero;
    private Vector3 baselineLocalScale = Vector3.one;
    [Tooltip("Extra multiplier applied to unlocked icon scale (1 = same size, 1.05 = 5% bigger).")]
    [SerializeField] private float sizeMultiplier = 1.05f;

    private void Start()
    {
        // capture baseline sprite size and scale so we can match replacement icons
        if (foodIconRenderer != null)
        {
            baselineLocalScale = foodIconRenderer.transform.localScale;
            if (foodIconRenderer.sprite != null)
            {
                var b = foodIconRenderer.sprite.bounds;
                targetSpriteWorldSize = new Vector2(b.size.x * baselineLocalScale.x, b.size.y * baselineLocalScale.y);
            }
        }

        UpdateVisuals();
    }

    public void Refresh()
    {
        UpdateVisuals();
    }



    public void UpdateVisuals()
    {
        if (itemData == null) return;

        // Sprite (set first so we can adjust scale)
        if (foodIconRenderer != null)
            foodIconRenderer.sprite = itemData.icon;

        // Only show unlocked visuals when the game's Progression explicitly marks the item unlocked.
        // Do NOT fall back to PlayerPrefs or unlockedByDefault — the user requested strict check against Progression.
        bool isUnlocked = false;
        var prog = Progression.Instance;
        if (prog != null)
            isUnlocked = IsUnlockedInProgression(prog, foodType);

        if (isUnlocked)
        {
            foodIconRenderer.color = unlockedColor;
            chanceText?.gameObject.SetActive(false);
            // ensure the unlocked icon fills the same area as the original (avoid tiny icon over locked image)
            if (autoMatchIconSize && foodIconRenderer.sprite != null && targetSpriteWorldSize != Vector2.zero)
            {
                TryMatchIconSize(foodIconRenderer.sprite);
            }
        }
        else
        {
            foodIconRenderer.color = lockedColor;
            if (chanceText != null)
            {
                chanceText.gameObject.SetActive(true);
                chanceText.text = itemData.dropChance + "%";
            }
        }
    }

    private void TryMatchIconSize(Sprite sprite)
    {
        if (sprite == null) return;
        var nb = sprite.bounds;
        if (nb.size.x <= 0f || nb.size.y <= 0f) return;

        // compute required localScale so that sprite.bounds * localScale == targetSpriteWorldSize
        float sx = targetSpriteWorldSize.x / nb.size.x;
        float sy = targetSpriteWorldSize.y / nb.size.y;

        // apply small multiplier so unlocked icons can be slightly larger than the locked placeholder
        sx *= sizeMultiplier;
        sy *= sizeMultiplier;

        // preserve Z scale from baseline
        foodIconRenderer.transform.localScale = new Vector3(sx, sy, baselineLocalScale.z);
    }

    public void UnlockItem()
    {
        PlayerPrefs.SetInt(itemData.itemName, 1);
        PlayerPrefs.Save();
        UpdateVisuals();
    }

    public enum FoodType
    {
        BaconEggCheese,
        Burger,
        CaesarSalad,
        Omelette,
        Pancakes,
        Quesadilla,
        ScrambledEggs,
        Waffles,
        Coffee,
        IcedCoffee,
        MangoPeachSmoothie,
        MatchaLatte,
        PineCocoSmoothie,
        StrawBanSmoothie,
        VanFrappe,
        FruitYogurt
    }

    // Helper: check corresponding Progression boolean for a FoodType
    private bool IsUnlockedInProgression(Progression prog, FoodType ft)
    {
        switch (ft)
        {
            case FoodType.BaconEggCheese: return prog.hasBaconEggCheese;
            case FoodType.Burger: return prog.hasBurger;
            case FoodType.CaesarSalad: return prog.hasCaesarSalad;
            case FoodType.Omelette: return prog.hasOmelette;
            case FoodType.Pancakes: return prog.hasPancakes;
            case FoodType.Quesadilla: return prog.hasQuesadilla;
            case FoodType.ScrambledEggs: return prog.hasScrambledEggs;
            case FoodType.Waffles: return prog.hasWaffles;
            case FoodType.Coffee: return prog.hasCoffee;
            case FoodType.IcedCoffee: return prog.hasIcedCoffee;
            case FoodType.MangoPeachSmoothie: return prog.hasMangoPeachSmoothie;
            case FoodType.MatchaLatte: return prog.hasMatchaLatte;
            case FoodType.PineCocoSmoothie: return prog.hasPineCocoSmoothie;
            case FoodType.StrawBanSmoothie: return prog.hasStrawBanSmoothie;
            case FoodType.VanFrappe: return prog.hasVanFrappe;
            case FoodType.FruitYogurt: return prog.hasFruitYogurt;
            default: return false;
        }
    }
}