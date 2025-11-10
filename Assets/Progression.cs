using UnityEngine;

public class Progression : MonoBehaviour
{
    public int coins = 10;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GainCurrency();
        }
    }

    void GainCurrency()
    {
        coins += 5;
    }
}
