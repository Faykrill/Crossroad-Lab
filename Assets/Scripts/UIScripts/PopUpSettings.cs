using UnityEngine;

public class PopUpSettings : MonoBehaviour
{
    public GameObject _popup;
    public void ShowPopUp()
    {
        _popup.SetActive(true);
    }
    
    public void HidePopUp ()
    {
        _popup.SetActive(false);
    }
}
