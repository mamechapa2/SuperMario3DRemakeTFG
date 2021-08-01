using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject optionsMenuObject;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayRandomGame()
    {
        SceneManager.LoadScene(19);
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

    public void OptionsMenu()
    {
        optionsMenuObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
