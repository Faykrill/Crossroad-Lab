using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public void QuitApplication()
    {
        Debug.Log("Quit Application");
        Application.Quit();
        
    }
}
