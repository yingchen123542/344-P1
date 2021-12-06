//https://www.youtube.com/watch?v=9dYDBomQpBQ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            if(isPaused) {ResumeGame();}
            else {PauseGame();}
        }

    }

    

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
			Time.timeScale = 0.0001f;

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
        isPaused = true;
        Cursor.visible = true;
        FindObjectOfType<StarterAssets.StarterAssetsInputs>().cursorLocked = false;
        FindObjectOfType<StarterAssets.StarterAssetsInputs>().cursorInputForLook = false;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
			Time.timeScale = 1f;

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
        isPaused = false;
        Cursor.visible = false;
        FindObjectOfType<StarterAssets.StarterAssetsInputs>().cursorLocked = true;
        FindObjectOfType<StarterAssets.StarterAssetsInputs>().cursorInputForLook = true;
    }

    public void PauseToggle()
    {
        if (isPaused) 
        {
			Time.timeScale = 0.0001f;

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if (!isPaused) 
        {
			Time.timeScale = 1f;

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
	
		}
    }
}
