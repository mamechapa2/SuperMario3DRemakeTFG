using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMainMenu : MonoBehaviour
{
    public GameObject mainMenuObject;
    public GameObject mainMenuMusic;
    public void goToMainMenu()
    {
        this.gameObject.SetActive(false);
        mainMenuObject.SetActive(true);
        mainMenuMusic.SetActive(true);
    }

}
