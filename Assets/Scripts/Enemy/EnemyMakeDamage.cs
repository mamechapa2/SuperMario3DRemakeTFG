using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
                GetComponent<Collider>().enabled = false;

                GameControl.damageReceived();

                StartCoroutine(activateCollider());
        }
    }

    private IEnumerator activateCollider()
    {
        yield return new WaitForSeconds(2f);

        GetComponent<Collider>().enabled = true;
    }
}
