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
            GameControl.damageReceived();

            StartCoroutine(activateCollider());
        }
    }

    private IEnumerator activateCollider()
    {
        yield return new WaitForSeconds(2f);

        GetComponent<BoxCollider>().enabled = true;
    }
}
