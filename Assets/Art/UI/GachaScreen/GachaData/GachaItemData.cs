using UnityEngine;

[CreateAssetMenu(fileName = "New Menu Item", menuName = "Gacha/Menu Item")]
public class GachaItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [Range(0, 100)] public float dropChance; // Adds a slider from 0 to 100
    public bool unlockedByDefault; // Check this for the first 4 items
}