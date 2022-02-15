using UnityEngine;
public class LevelButtons : MonoBehaviour
{
    [SerializeField] private int typeButton = 0;
    [SerializeField] private GameObject global;

    public void ButtonAction()
    {
        global.GetComponent<GlobalScript>().GiveAnswer(typeButton);
    }
}
