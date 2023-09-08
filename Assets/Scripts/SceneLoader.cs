using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int currentScene = 0;
    private int maxScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        maxScene = SceneManager.sceneCountInBuildSettings - 1;

        DontDestroyOnLoad(gameObject);

        if (GameObject.Find("SceneLoader") != gameObject)
        {
            Destroy(GameObject.Find("SceneLoader"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.PageUp))
        {
            LoadNextScene();
        }

        if(Input.GetKeyDown(KeyCode.PageDown))
        {
            LoadPreviousScene();
        }
    }

    private void LoadNextScene()
    {
        if(currentScene + 1 > maxScene)
        {
            SceneManager.LoadScene(0);
            currentScene = 0;
        } 
        else
        {
            SceneManager.LoadScene(currentScene + 1);
            currentScene++;
        }
    }

    private void LoadPreviousScene()
    {
        if(currentScene - 1 < 0)
        {
            SceneManager.LoadScene(maxScene);
            currentScene = maxScene;
        } 
        else
        {
            SceneManager.LoadScene(currentScene - 1);
            currentScene--;
        }
    }
}
