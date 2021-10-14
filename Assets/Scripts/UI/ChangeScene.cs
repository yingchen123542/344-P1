using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//https://www.youtube.com/watch?v=26d1uZ7yrfY

public class ChangeScene : MonoBehaviour
{
    public bool isGoNextScene = true;
    // Start is called before the first frame update
    public int sceneToLoad;

    // Update is called once per frame
    public void ChangeScenes()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();

        
        if(isGoNextScene)
        {
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        
        //resets challenge
        //Challenge.Instance.challenge = 0;
    }
}
