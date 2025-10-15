using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplianceButton : MonoBehaviour
{
    public bool enableDisable;
    public GameObject fridgePanel;
    public GameObject stovePanel;
    public GameObject displayPanel;
    public GameObject coffeeMachinePanel;
    public GameObject cabinetPanel;


    public void FridgePopUp()
    {
        if (enableDisable = !enableDisable)
        {
            fridgePanel.SetActive(true);
            displayPanel.SetActive(false);
            stovePanel.SetActive(false);
            cabinetPanel.SetActive(false);
            coffeeMachinePanel.SetActive(false);
            
        }
        else
        {
            fridgePanel.SetActive(false);
        }
    }
    public void CoffeeMachinePopUp()
    {
        if (enableDisable = !enableDisable)
        {
            coffeeMachinePanel.SetActive(true);
            displayPanel.SetActive(false);
            stovePanel.SetActive(false);
            cabinetPanel.SetActive(false);
            
        }
        else
        {
            coffeeMachinePanel.SetActive(false);
        }
    }
    
    public void CabinetPopUp()
    {
        if (enableDisable = !enableDisable)
        {
            cabinetPanel.SetActive(true);
            displayPanel.SetActive(false);
            stovePanel.SetActive(false);
            coffeeMachinePanel.SetActive(false);
            
        }
        else
        {
            cabinetPanel.SetActive(false);
        }
    }

    public void Stovepopup()
    {
        if (enableDisable = !enableDisable)
        {
            stovePanel.SetActive(true);
            fridgePanel.SetActive(false);
            displayPanel.SetActive(false);
            cabinetPanel.SetActive(false);
            coffeeMachinePanel.SetActive(false);
            
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
            cabinetPanel.SetActive(false);
            coffeeMachinePanel.SetActive(false);
            
        }
        else
        {
            displayPanel.SetActive(false);
        }
    }


}

