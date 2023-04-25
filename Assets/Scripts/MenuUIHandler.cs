using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Start a new scene
    public void StartNew()
    {
       SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
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
