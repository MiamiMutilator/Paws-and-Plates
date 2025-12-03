using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainGame()
    {
        if (Progression.Instance.hasBeachTheme == true)
        {
            SceneManager.LoadScene("OrdersBeach");
        }
        else if (Progression.Instance.hasCozyTheme == true)
        {
            SceneManager.LoadScene("OrdersCozy");
        }
        else if (Progression.Instance.hasSpaceTheme == true)
        {
            SceneManager.LoadScene("OrdersSpace");
        }
        else if (Progression.Instance.hasModernTheme == true)
        {
            SceneManager.LoadScene("OrdersModern");
        }
        else
        {
            SceneManager.LoadScene("Orders");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void LoadGacha()
    {
        SceneManager.LoadScene("Gacha");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void ThemeShop()
    {
        SceneManager.LoadScene("ThemeShop");
    }
}
