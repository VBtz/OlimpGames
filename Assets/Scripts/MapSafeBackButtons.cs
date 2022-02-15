using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MapSafeBackButtons : MonoBehaviour
{
    [SerializeField] private int buttonType;
    [SerializeField] private GameObject mainMenu, currentMenu, safeMenu;
    [SerializeField] private Image fillimage;

    public void ButtonAction()
    {
        fillimage.enabled = true;
        if (buttonType == 0)
        {
            fillimage.DOFade(1, 0.5f).OnComplete(() =>
            {
                currentMenu.SetActive(false);
                mainMenu.SetActive(true);
                fillimage.DOFade(0, 0.5f).OnComplete(() => fillimage.enabled = false);
            });
            
        }
        else
        {
            fillimage.DOFade(1, 0.5f).OnComplete(() =>
            {
                currentMenu.SetActive(false);
                safeMenu.SetActive(true);
                fillimage.DOFade(0, 0.5f).OnComplete(() => fillimage.enabled = false);
            });
        }
    }
}
