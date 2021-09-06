using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            //Desactivamos el collider temporalmente
            GetComponent<Collider>().enabled = false;

            GameControl.damageReceived();

            //Activamos la corutina para reactivar el collider
            StartCoroutine(activateCollider());
        }
    }

    private IEnumerator activateCollider()
    {
        yield return new WaitForSeconds(2f);

        GetComponent<Collider>().enabled = true;
    }
}
