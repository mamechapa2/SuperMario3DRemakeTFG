using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreballMove : MonoBehaviour
{
    public float speed = 6;

    // Update is called once per frame
    void Update()
    {
        //Mueve la bola a una velocidad
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
}
