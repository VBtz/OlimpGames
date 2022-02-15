using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class WinButtons : MonoBehaviour
{
    [SerializeField] private int typeButton;
    [SerializeField] private GameObject mapMenu, mainMenu, currentMenu;
    [SerializeField] private Image fillimage;

    public void ButtonAction()
    {
        fillimage.enabled = true;
        if (typeButton == 0)
        {
            fillimage.DOFade(1, 0.5f).OnComplete(() =>
            {
                currentMenu.SetActive(false);
                mapMenu.SetActive(true);
                fillimage.DOFade(0, 0.5f).OnComplete(() => fillimage.enabled = false);
            });
        }
        else
        {
            fillimage.DOFade(1, 0.5f).OnComplete(() =>
            {
                currentMenu.SetActive(false);
                mainMenu.SetActive(true);
                fillimage.DOFade(0, 0.5f).OnComplete(() => fillimage.enabled = false);
            });
        }
    }
}
