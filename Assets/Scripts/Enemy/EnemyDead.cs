using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    public GameObject goombaObject;
    public GameObject makeDamageTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //Desactivar animacion, collider, movimiento y script de hacer daño
            goombaObject.GetComponentInChildren<Animator>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponentInParent<EnemyMove2D>().enabled = false;
            goombaObject.GetComponentInChildren<EnemyMakeDamage>().enabled = false;
            makeDamageTrigger.SetActive(false);

            //Reproducir sonido
            GameObject.Find("EnemyDead").GetComponent<AudioSource>().Play();
            
            //Aplastar
            goombaObject.transform.localScale = new Vector3(1, 0.5f, 1);
            goombaObject.transform.position = new Vector3(goombaObject.transform.position.x, goombaObject.transform.position.y - 0.5f, goombaObject.transform.position.z);
            
            StartCoroutine(disappear());
        }
    }

    //Hace desaparecer al enemigo y añade la puntuacion correspondiente
    private IEnumerator disappear()
    {
        GameControl.addScore(100);

        yield return new WaitForSeconds(2f);

        goombaObject.SetActive(false);
    }
}
