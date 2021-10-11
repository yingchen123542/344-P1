using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//https://www.youtube.com/watch?v=26d1uZ7yrfY

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneToLoad;

    // Update is called once per frame
    public void ChangeScenes()
    {
        SceneManager.LoadScene(sceneToLoad);
        //resets challenge
        Challenge.Instance.challenge = 0;
    }
}
