using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMainMenu : MonoBehaviour
{
    public GameObject mainMenuObject;
    public void goToMainMenu()
    {
        this.gameObject.SetActive(false);
        mainMenuObject.SetActive(true);
    }

}
