using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FallButton : MonoBehaviour
{
    [SerializeField] private GameObject globalscript, currentMenu, levelMenu;
    [SerializeField] private Image fillimage;
    public void FallAction()
    {
        fillimage.enabled = true;
        fillimage.DOFade(1, 0.5f).OnComplete(() =>
        {
            currentMenu.SetActive(false);
            levelMenu.SetActive(true);
            GlobalScript global = globalscript.GetComponent<GlobalScript>();
            global.questNumber = 0;
            global.UpdateAnswer(global.questType, 0);
            fillimage.DOFade(0, 0.5f).OnComplete(() => fillimage.enabled = false);
        });
    }
}
