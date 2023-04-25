using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    
    // Start a new scene
    public void StartNew()
    {
       //MainManager.Instance.SetUsername(username);
       SceneManager.LoadScene(1);
    }

     // Exits the application
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); // to quit when playing in Unity Editor
#else
        Application.Quit(); // original code to quit Unity Player
#endif
    }

}
