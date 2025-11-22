using UnityEngine;

// This line adds a button to your Right-Click menu in Unity!
[CreateAssetMenu(fileName = "New Theme", menuName = "Restaurant Theme")]
public class ThemeData : ScriptableObject
{
    public string themeName;         // Name of the theme (e.g., "Spooky")
    public int price;                // Cost (e.g., 500)
    public Sprite iconImage;         // The small square picture
    public Sprite fullScreenImage;   // The big phone-sized picture
}