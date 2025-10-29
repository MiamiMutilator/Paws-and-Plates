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
    public Image fillImage;
    public Image backgroundImage;

    public float timeToCook = 5f;
    public Vector2 cookedRange = new Vector2(0.45f, 0.6f);

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
        if (cookMeter.value < cookedRange.x)
        {
            fillImage.color = Color.yellow;
            backgroundImage.color = Color.yellow;
        }
        else if (cookMeter.value > cookedRange.y)
        {
            fillImage.color = Color.red;
            backgroundImage.color = Color.red;
        }
        else
        {
            fillImage.color = Color.green;
            backgroundImage.color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCooking) return;

        if (cookMap.ContainsKey(collision.tag))
        {
            currentItemTag = collision.tag;
            Destroy(collision.gameObject);
            StartCoroutine(Cooking());
        }
    }

    private IEnumerator Cooking()
    {
        isCooking = true;
        cookMeter.gameObject.SetActive(true);
        cookMeter.value = 0f;

        float timer = 0f;

        while (timer < timeToCook)
        {
            timer += Time.deltaTime;
            cookMeter.value = timer / timeToCook;

            if (Input.GetMouseButtonDown(0))
            {
                yield return CookingResult(cookMeter.value);
                yield break;
            }
            yield return null;
        }
        yield return CookingResult(1.1f);

    }

    private IEnumerator CookingResult(float progress)
    {
        cookMeter.gameObject.SetActive(false);

        var (raw, cooked, burnt) = cookMap[currentItemTag];
        GameObject result = null;

        if (progress < cookedRange.x)
        {
            Debug.Log("Too early!");
            result = raw;
        }
        else if (progress > cookedRange.y)
        {
            Debug.Log("Too Late!");
            fillImage.color = Color.red;
            backgroundImage.color = Color.red;
            result = burnt;
        }
        else
        {
            Debug.Log("Perfect!");
            fillImage.color = Color.green;
            backgroundImage.color = Color.green;
            result = cooked;
        }

        yield return new WaitForSeconds(0.3f);
        AddCookedItemToInventory(result);

        isCooking = false;
        currentItemTag = "";

    }

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
