using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MapButtons : MonoBehaviour
{
    [SerializeField] private int typeButtons;
    [SerializeField] private GameObject currentMenu, menuLevel, globalScript;
    [SerializeField] private Image fillimage;

    public void ButtonAction()
    {
        fillimage.enabled = true;
        fillimage.DOFade(1, 0.5f).OnComplete(() =>
        {
            GlobalScript global = globalScript.GetComponent<GlobalScript>();
            currentMenu.SetActive(false);
            menuLevel.SetActive(true);
            global.UpdateAnswer(typeButtons, 0);
            fillimage.DOFade(0, 0.5f).OnComplete(() => fillimage.enabled = false);
        });
    }
}
