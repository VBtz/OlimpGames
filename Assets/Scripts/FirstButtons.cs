using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FirstButtons : MonoBehaviour
{
    [SerializeField] private int buttonType;
    [SerializeField] private GameObject mapMenu, currentMenu, missionMenu;
    [SerializeField] private Image fillimage;

    public void ButtonAction()
    {
        if(buttonType == 0)
        {
            fillimage.enabled = true;
            fillimage.DOFade(1, 0.5f).OnComplete(() =>
            {
                currentMenu.SetActive(false);
                mapMenu.SetActive(true);
                fillimage.DOFade(0, 0.5f).OnComplete(() => fillimage.enabled = false); ;
            });
            
        }
        else
        {
            fillimage.enabled = true;
            fillimage.DOFade(1, 0.5f).OnComplete(() =>
            {
                currentMenu.SetActive(false);
                missionMenu.SetActive(true);
                fillimage.DOFade(0, 0.5f);
                fillimage.enabled = false;
            });
        }
    }
}
