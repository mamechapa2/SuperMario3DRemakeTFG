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
        //Si se pulsa escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) //Si ya estaba pausado, reactiva el juego
            {
                resumeGame();
            }
            else //Sino lo pausa
            {
                pauseGame();
            }
        }
    }

    private void resumeGame()
    {
        //Reactiva la musica
        GameObject.Find("LevelMusic").GetComponent<AudioSource>().Play();

        //Desactiva el objeto del menu
        pauseMenuObject.SetActive(false);

        //Cambia la escala de tiempo a la normal
        Time.timeScale = 1f;
        paused = false;
    }

    private void pauseGame()
    {
        //Pausa la musica
        GameObject.Find("LevelMusic").GetComponent<AudioSource>().Pause();

        //Activa el objeto del menu
        pauseMenuObject.SetActive(true);

        //Cambia la escala de tiempo a 0 para pausar el tiempo
        Time.timeScale = 0f;
        paused = true;
    }

    private void Start()
    {
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    //Opciones de los botones del menu
    public void resume()
    {
        resumeGame();
    }

    public void quit()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        SceneManager.LoadScene(0);
    }
}
