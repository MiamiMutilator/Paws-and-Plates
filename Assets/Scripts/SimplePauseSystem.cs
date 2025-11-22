using UnityEngine;
using UnityEngine.UI; // For UI Images
using System.Collections.Generic; // For Lists

public class SimplePauseSystem : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject pauseButton;

    [Header("Appliances (UI Images)")]
    [Tooltip("Drag UI appliances here.")]
    [SerializeField] private List<Image> appliances; 

    [Header("Dynamic Characters (Sprites)")]
    [Tooltip("Type the exact Tag name of your characters here.")]
    [SerializeField] private string characterTag = "Player"; 
    
    // Internal list to remember which characters we dimmed
    private List<SpriteRenderer> dimmedCharacters = new List<SpriteRenderer>();

    private Color normalColor = Color.white;
    private Color dimmedColor = new Color(0.5f, 0.5f, 0.5f, 1f); // Dark Grey

    private void Start()
    {
        Time.timeScale = 1f;
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(false);
        if (pauseButton != null) pauseButton.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(true);
        if (pauseButton != null) pauseButton.SetActive(false);

        // 1. Dim Appliances (UI)
        foreach (Image app in appliances)
        {
            if (app != null) app.color = dimmedColor;
        }

        // 2. Dim Dynamic Characters (Sprites)
        FindAndDimCharacters();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(false);
        if (pauseButton != null) pauseButton.SetActive(true);

        // 1. Restore Appliances
        foreach (Image app in appliances)
        {
            if (app != null) app.color = normalColor;
        }

        // 2. Restore Characters
        foreach (SpriteRenderer sr in dimmedCharacters)
        {
            if (sr != null) sr.color = normalColor;
        }
        
        // Clear the list so we can find them fresh next time
        dimmedCharacters.Clear();
    }

    private void FindAndDimCharacters()
    {
        // Find every object in the scene with the specific Tag
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag(characterTag);

        foreach (GameObject obj in foundObjects)
        {
            // Get the SpriteRenderer (what makes them visible)
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            
            if (sr != null)
            {
                sr.color = dimmedColor;
                dimmedCharacters.Add(sr); // Add to list so we can undim them later
            }
        }
    }
}