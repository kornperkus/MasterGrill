using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenu : MonoBehaviour
{
    public void OnPlayClicked() {
        SceneManager.LoadScene(1);
    }

    public void OnExitClicked() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
