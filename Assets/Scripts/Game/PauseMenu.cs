using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuObject;
    private bool paused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    private void resumeGame()
    {
        GameObject.Find("LevelMusic").GetComponent<AudioSource>().Play();
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    private void pauseGame()
    {
        GameObject.Find("LevelMusic").GetComponent<AudioSource>().Pause();
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    private void Start()
    {
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }
    public void resume()
    {
        Debug.Log("Resume");
        resumeGame();
    }

    public void quit()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

    public void mainMenu()
    {
        Debug.Log("MainMenu");
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        SceneManager.LoadScene(0);
    }
}
