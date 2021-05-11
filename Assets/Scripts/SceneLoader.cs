using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public static SceneLoader loader = null;

    void Awake()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (loader == null)
        {
            DontDestroyOnLoad(this.gameObject);
            loader = this;
        } 
        else
        {
            Destroy(loader.gameObject);
            loader = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (this != loader) return;

        if (scene.name.Equals("MenuScene"))
        {
            
        }
    }

    public void Load(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
