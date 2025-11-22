using UnityEngine;
using UnityEngine.UI; 
using System.Collections.Generic; 

public class SimplePauseSystem : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject pauseButton;

    [Header("Appliances (UI Images)")]
    [Tooltip("Drag UI appliances here.")]
    [SerializeField] private List<Image> appliances; 

    [Header("Dynamic Characters")]
    [Tooltip("Type the exact Tag name of your characters here.")]
    [SerializeField] private string characterTag = "Walker"; // Check your Tag!
    
    // CHANGED: We now store a list of ALL renderers found (Body + Bubbles + Etc)
    private List<SpriteRenderer> dimmedSprites = new List<SpriteRenderer>();

    private Color normalColor = Color.white;
    private Color dimmedColor = new Color(0.5f, 0.5f, 0.5f, 1f); 

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

        foreach (Image app in appliances)
        {
            if (app != null) app.color = dimmedColor;
        }

        FindAndDimCharacters();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(false);
        if (pauseButton != null) pauseButton.SetActive(true);

        foreach (Image app in appliances)
        {
            if (app != null) app.color = normalColor;
        }

        // Restore ALL sprites (Bubbles included)
        foreach (SpriteRenderer sr in dimmedSprites)
        {
            if (sr != null) sr.color = normalColor;
        }
        
        dimmedSprites.Clear();
    }

    private void FindAndDimCharacters()
    {
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag(characterTag);

        foreach (GameObject obj in foundObjects)
        {
            // CHANGED: usage of GetComponentsInChildren (Plural)
            // This grabs the Body, the Chat Bubble, hats, etc.
            SpriteRenderer[] allRenderers = obj.GetComponentsInChildren<SpriteRenderer>();
            
            foreach (SpriteRenderer sr in allRenderers)
            {
                sr.color = dimmedColor;
                dimmedSprites.Add(sr); 
            }
        }
    }
}