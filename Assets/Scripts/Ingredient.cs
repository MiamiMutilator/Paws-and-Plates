using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public CollectableType type;
    public Player player;
    public Sprite icon;
    public InventoryUi inventoryUi;
    public GameObject ingredientPrefab;



    public void IngredientButton()
    {
        //player.inventory.Add(this);
        inventoryUi.Setup();

        spawnIngredient();
    }

    public void spawnIngredient()
    {
        foreach (SlotUi slot in inventoryUi.slots)
        {
            bool isEmpty = slot.itemIcon.sprite == null && slot.transform.childCount <= 1;

            if (isEmpty)
            {
                GameObject spawned = Instantiate(ingredientPrefab, slot.transform);
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

public enum CollectableType
{
    NONE,
    MILK,
    MATCHA,
    BANANA,
    STRAWBERRY,
    COFFEE,
    ICE,
    PINEAPPLE,
    MANGO,
    VANILLA,
    COCONUT,
    PEACH,
    BURGER,
    RAWPATTY,
    RAWBACON,
    ESPRESSO,
    BUN,
    SPINACH,
    ONION,
    TORTILLA,
    TOMATO,
    YOGURT,
    FLOUR,
    CHEESE,
    BUTTER,
    LETTUCE,
    GREENONION,
    EGG,
    BACON,
    CROUTONS

}
