using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaDead : MonoBehaviour
{
    public GameObject koopaObject;
    public GameObject shellObject;
    public GameObject koopaMovementObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //Desactivar animacion, collider, movimiento y script de hacer daño
            koopaObject.SetActive(false);
            koopaMovementObject.GetComponent<EnemyMove2D>().enabled = false;
            shellObject.SetActive(true);
            GameControl.addScore(100);

            //Reproducir sonido
            GameObject.Find("EnemyDead").GetComponent<AudioSource>().Play();
        }
    }
}
