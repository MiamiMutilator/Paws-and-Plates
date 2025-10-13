using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplianceButton : MonoBehaviour
{
    public bool enableDisable;
    public GameObject fridgePanel;
    public GameObject stovePanel;
    public GameObject displayPanel;


    public void FridgePopUp()
    {
        if (enableDisable = !enableDisable)
        {
            fridgePanel.SetActive(true);
            displayPanel.SetActive(false);
            stovePanel.SetActive(false);
        }
        else
        {
            fridgePanel.SetActive(false);
        }
    }

    public void Stovepopup()
    {
        if (enableDisable = !enableDisable)
        {
            stovePanel.SetActive(true);
            fridgePanel.SetActive(false);
            displayPanel.SetActive(false);
        }
        else
        {
            stovePanel.SetActive(false);
        }
    }

    public void Displaypopup()
    {
        if (enableDisable = !enableDisable)
        {
            displayPanel.SetActive(true);
            fridgePanel.SetActive(false);
            stovePanel.SetActive(false);
        }
        else
        {
            displayPanel.SetActive(false);
        }
    }


}

