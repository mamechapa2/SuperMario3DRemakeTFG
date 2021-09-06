using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlockBreak : MonoBehaviour
{
    public GameObject brick;
    public GameObject breakBrick;
    public BoxCollider colliderBrick;

    public bool containsCoin = false;

    public Animator brickAnimator;
    private void OnTriggerEnter(Collider other)
    {
        //Si Mario tiene un powerup
        if (GameControl.isBigMario())
        {
            //Cambiamos el modelo del bloque y reproducimos el sonido
            GameObject.Find("BrickBreak").GetComponent<AudioSource>().Play();
            GetComponent<BoxCollider>().enabled = false;
            colliderBrick.enabled = false;
            brick.SetActive(false);
            breakBrick.SetActive(true);

            //Si tiene moneda, la añadimos
            if (containsCoin)
            {
                GameControl.increaseCoins();
            }

            //Eliminamos el bloque
            StartCoroutine(destroyBlock());
        }
        else
        {
            //Si Mario es pequeño el bloque "bota"
            GameObject.Find("BrickNotBreak").GetComponent<AudioSource>().Play();
            brickAnimator.SetBool("bounce", true);
            StartCoroutine(stopBouncing());
        }
    }

    private IEnumerator destroyBlock()
    {
        yield return new WaitForSeconds(1.13f);
        breakBrick.SetActive(false);
    }

    private IEnumerator stopBouncing()
    {
        yield return new WaitForSeconds(0.18f);
        brickAnimator.SetBool("bounce", false);
    }
}
