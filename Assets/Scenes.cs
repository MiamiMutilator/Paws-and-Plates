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
        SceneManager.LoadScene("Orders");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void LoadGacha()
    {
        SceneManager.LoadScene("Gacha");
    }
}
