using UnityEngine;
using TMPro; // Needed for TextMeshPro

public class GachaItemDisplay : MonoBehaviour
{
    [Header("The Data")]
    public GachaItemData itemData; 

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

    public void UpdateVisuals()
    {
        if (itemData == null) return;

        // 1. Set the Sprite on the Renderer
        if (foodIconRenderer != null) 
        {
            foodIconRenderer.sprite = itemData.icon;
        }

        // 2. Check Memory
        bool isUnlocked = PlayerPrefs.GetInt(itemData.itemName, 0) == 1 || itemData.unlockedByDefault;

        if (isUnlocked)
        {
            // UNLOCKED (White)
            if (foodIconRenderer != null) foodIconRenderer.color = unlockedColor;
            
            if (chanceText != null) chanceText.gameObject.SetActive(false);
        }
        else
        {
            // LOCKED (Grey #555555)
            if (foodIconRenderer != null) foodIconRenderer.color = lockedColor;

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
}