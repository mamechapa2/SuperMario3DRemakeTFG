using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMainMenu : MonoBehaviour
{
    public GameObject mainMenuObject;
    public GameObject mainMenuMusic;

    private void Update()
    {
        if (Input.anyKey)
        {
            this.gameObject.SetActive(false);
            mainMenuObject.SetActive(true);
            mainMenuMusic.SetActive(true);
        }
    }
    public void goToMainMenu()
    {
        this.gameObject.SetActive(false);
        mainMenuObject.SetActive(true);
        mainMenuMusic.SetActive(true);
    }

}
