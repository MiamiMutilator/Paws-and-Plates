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

    private void Start()
    {
        UpdateVisuals();
    }

    public void Refresh()
    {
        UpdateVisuals();
    }



    public void UpdateVisuals()
    {
        if (itemData == null) return;

        // Sprite
        if (foodIconRenderer != null)
            foodIconRenderer.sprite = itemData.icon;

        bool isUnlocked = false;

        if (Progression.Instance != null)
            isUnlocked = Progression.Instance.IsUnlocked(foodType);

        if (!isUnlocked)
            isUnlocked = PlayerPrefs.GetInt(itemData.itemName, 0) == 1 || itemData.unlockedByDefault;

        if (isUnlocked)
        {
            foodIconRenderer.color = unlockedColor;
            chanceText?.gameObject.SetActive(false);
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
}