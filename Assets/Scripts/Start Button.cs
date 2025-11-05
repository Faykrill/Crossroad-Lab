using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]private int sceneIndex;
    public void LoadSceneByIndex()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
