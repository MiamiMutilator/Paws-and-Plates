using UnityEngine;
using System.Collections.Generic;

public class Stove : MonoBehaviour
{
    public InventoryUi inventoryUi;
    public GameObject CookedPatty;
    public GameObject CookedBacon;

    private Dictionary<string, GameObject> cookMap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cookMap = new Dictionary<string, GameObject>()
        {
            { "RawPatty", CookedPatty },
            { "RawBacon", CookedBacon }
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cookMap.TryGetValue(collision.tag, out GameObject cookedPrefab))
        {
            Destroy(collision.gameObject); 

            AddCookedItemToInventory(cookedPrefab);
        }
    }

    private void AddCookedItemToInventory(GameObject cookedPrefab)
    {
        inventoryUi.Setup();

        foreach (SlotUi slot in inventoryUi.slots)
        {
            bool isEmpty = slot.itemIcon.sprite == null && slot.transform.childCount <= 1;
            if (isEmpty)
            {
                GameObject spawned = Instantiate(cookedPrefab, slot.transform);
                RectTransform rt = spawned.GetComponent<RectTransform>();

                rt.anchorMin = rt.anchorMax = rt.pivot = new Vector2(0.5f, 0.5f);
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
