using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public CollectableType type;
    public Player player;
    public Sprite icon;


    public void IngredientButton()
    {
        player.inventory.Add(this);
    }

}

public enum CollectableType
{
    NONE,
    MILK,
    MATCHA,
    BANANA,
    STRAWBERRY,
    COFFEE,
    ICE
}
