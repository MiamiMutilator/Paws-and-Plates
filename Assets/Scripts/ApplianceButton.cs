using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplianceButton : MonoBehaviour
{
    public GameObject ingredientsPanel;
    public bool enableDisable;

    public void IngredientsPopUp()
    {
        if (enableDisable = !enableDisable)
        {
            ingredientsPanel.SetActive(false);
        }
        else
        {
            ingredientsPanel.SetActive(true);
        }
    }


}
