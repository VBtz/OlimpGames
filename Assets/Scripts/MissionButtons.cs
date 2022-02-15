using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionButtons : MonoBehaviour
{
    [SerializeField] private int buttonType;
    [SerializeField] private GameObject mapMenu, currentMenu, mainMenu;

    public void ButtonAction()
    {
        if (buttonType == 0)
        {
            currentMenu.SetActive(false);
            mapMenu.SetActive(true);
        }
        else
        {
            currentMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
