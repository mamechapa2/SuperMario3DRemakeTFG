using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            //TODO REPRODUCIR SONIDO
            GameControl.damageReceived();
            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<BoxCollider>().enabled = true;
    }
}
