using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Stove : MonoBehaviour
{
    public InventoryUi inventoryUi;

    public GameObject RawPatty;
    public GameObject CookedPatty;
    public GameObject BurntPatty;

    public GameObject RawBacon;
    public GameObject CookedBacon;
    public GameObject BurntBacon;

    public Slider cookMeter;
    public float timeToCook = 5f;

    private Dictionary<string, (GameObject raw, GameObject cooked, GameObject burnt)> cookMap;
    bool isCooking;
    private string currentItemTag = "";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set up mapping between raw items and cooked/burnt versions
        cookMap = new Dictionary<string, (GameObject, GameObject, GameObject)>()
        {
            { "RawPatty", (RawPatty, CookedPatty, BurntPatty) },
            { "RawBacon", (RawBacon, CookedBacon, BurntBacon) }
        };

        cookMeter.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCooking) return;

        if (cookMap.ContainsKey(collision.tag))
        {
            currentItemTag = collision.tag;
            Destroy(collision.gameObject);
        }
    }

    //private IEnumerator Cooking()
    //{
    //    isCooking = true;
    //    cookMeter.gameObject.SetActive(true);
    //    cookMeter.value = 0f;

    //    float timer = 0f;

    //    while (timer < timeToCook)
    //    {
    //        timer += Time.deltaTime;
    //        cookMeter.value = timer / timeToCook;

    //        if (Input.GetMouseButtonDown(0))
    //        {

    //        }
    //        yield return null;
    //    }


    //}

    //private IEnumerator CookingResult(float progress)
    //{

    //}

    private void AddCookedItemToInventory(GameObject Prefab)
    {
        inventoryUi.Setup();

        foreach (SlotUi slot in inventoryUi.slots)
        {
            bool isEmpty = slot.itemIcon.sprite == null && slot.transform.childCount <= 1;
            if (isEmpty)
            {
                GameObject spawned = Instantiate(Prefab, slot.transform);
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
