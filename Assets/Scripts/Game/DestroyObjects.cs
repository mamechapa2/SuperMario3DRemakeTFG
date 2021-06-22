using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
        }catch(UnityException e)
        {
            Debug.Log("asda" + e.ToString());
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
