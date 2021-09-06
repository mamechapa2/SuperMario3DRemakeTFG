using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Elimina todos los objetos que se pasan entre escenas
        try
        {
            GameControl.resetGame();
            GameObject objectToDelete = GameObject.Find("@GameController").gameObject;
            Destroy(objectToDelete);

            objectToDelete = GameObject.Find("Audio").gameObject;
            Destroy(objectToDelete);

            objectToDelete = GameObject.Find("Canvas").gameObject;
            Destroy(objectToDelete);

            objectToDelete = GameObject.Find("Cameras").gameObject;
            Destroy(objectToDelete);

            objectToDelete = GameObject.Find("PlayerCC").gameObject;
            Destroy(objectToDelete);
        }catch(NullReferenceException e)
        {
            Debug.Log("Juego iniciado por primera vez: " + e.ToString()); //Si es la primera vez que se inicia, fallará
        }
    }
}
