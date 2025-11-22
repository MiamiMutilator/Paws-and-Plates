using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro; // <--- This is the key! It lets us talk to TextMeshPro.

public class ShopManager : MonoBehaviour
{
    [Header("The Data")]
    public List<ThemeData> allThemes;

    [Header("The Cookie Cutter")]
    public GameObject buttonTemplate;

    [Header("The Shelf")]
    public Transform gridContainer;

    [Header("The Screens")]
    public GameObject gridScreen;
    public GameObject detailScreen;

    [Header("Detail Screen Parts")]
    public Image bigImage;
    // UPDATED: Now accepts TextMeshPro
    public TextMeshProUGUI priceLabel; 
    
    [Header("Buy Controls")]
    public Button buyButton;
    // UPDATED: Now accepts TextMeshPro
    public TextMeshProUGUI buyButtonText; 

    private ThemeData activeTheme;

    void Start()
    {
        GenerateGrid();
        
        if (gridScreen != null) gridScreen.SetActive(true);
        if (detailScreen != null) detailScreen.SetActive(false);
    }

    private void GenerateGrid()
    {
        foreach (Transform child in gridContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (ThemeData data in allThemes)
        {
            GameObject newBtn = Instantiate(buttonTemplate, gridContainer);
            
            Image btnImage = newBtn.GetComponent<Image>();
            if (btnImage != null)
            {
                btnImage.sprite = data.iconImage;

                if (IsThemeOwned(data))
                {
                    btnImage.color = Color.gray; 
                }
                else
                {
                    btnImage.color = Color.white;
                }
            }

            newBtn.GetComponent<Button>().onClick.AddListener(() => OnThemeClicked(data));
        }
    }

    void OnThemeClicked(ThemeData data)
    {
        activeTheme = data;

        if (bigImage != null) bigImage.sprite = data.fullScreenImage;
        
        // Update the price text
        if (priceLabel != null) priceLabel.text = "$" + data.price;

        if (IsThemeOwned(data))
        {
            if (buyButton != null) buyButton.interactable = false;
            if (buyButtonText != null) buyButtonText.text = "Owned";
        }
        else
        {
            if (buyButton != null) buyButton.interactable = true;
            if (buyButtonText != null) buyButtonText.text = "Buy";
        }

        gridScreen.SetActive(false);
        detailScreen.SetActive(true);
    }

    public void CloseDetailScreen()
    {
        gridScreen.SetActive(true);
        detailScreen.SetActive(false);
        GenerateGrid(); 
    }

    public void BuyItem()
    {
        if (activeTheme == null) return;

        PlayerPrefs.SetInt(activeTheme.themeName, 1);
        PlayerPrefs.Save(); 

        Debug.Log("Bought: " + activeTheme.themeName);

        if (buyButton != null) buyButton.interactable = false;
        if (buyButtonText != null) buyButtonText.text = "Owned";
    }

    private bool IsThemeOwned(ThemeData data)
    {
        return PlayerPrefs.GetInt(data.themeName, 0) == 1;
    }
}