using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            transform.position = new Vector3(-1000, -1000, -1000);
            //TODO REPRODUCIR SONIDO
            GameControl.increaseStars();
        }
    }
}
