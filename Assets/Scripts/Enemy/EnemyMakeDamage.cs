using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                GetComponent<BoxCollider>().enabled = false;
                GameControl.damageReceived();

                StartCoroutine(activateCollider());
                break;
            default:
                Debug.Log(this.name + " asdasd " + other.name);
                transform.parent.gameObject.GetComponentInParent<EnemyMove2D>().direction = !transform.parent.gameObject.GetComponentInParent<EnemyMove2D>().direction;
                break;
        }
    }

    private IEnumerator activateCollider()
    {
        yield return new WaitForSeconds(2f);

        GetComponent<BoxCollider>().enabled = true;
    }
}
