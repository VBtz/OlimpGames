using UnityEngine;

public class SafeButtons : MonoBehaviour
{
    [SerializeField] private int typeButton;
    [SerializeField] private GameObject globalscript, mapMenu, currentMenu, finalMenu;

    public void ButtonAction()
    {
        GlobalScript global = globalscript.GetComponent<GlobalScript>();
        if(typeButton < 11)
        {
            if (global.password.Length < 5)
            {
                global.password = global.password + typeButton;
                global.UpdatePassword();
            }
        }
        else if (typeButton == 11)
        {
            global.password = "";
            currentMenu.SetActive(false);
            mapMenu.SetActive(true);
        }
        else if (typeButton == 12)
        {
            if(global.password == "89563")
            {
                global.password = "";
                currentMenu.SetActive(false);
                finalMenu.SetActive(true);
            }
            else
            {
                global.password = "";
                global.UpdatePassword();
            }
        }
    }
}
