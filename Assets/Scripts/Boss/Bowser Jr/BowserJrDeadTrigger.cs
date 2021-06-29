using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowserJrDeadTrigger : MonoBehaviour
{
    public GameObject switchOn;
    public GameObject switchOff;

    public GameObject explosionPrefab;
    public GameObject bossModelObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        switchOn.SetActive(false);
        switchOff.SetActive(true);
        transform.parent.GetComponentInChildren<BowserJrCharacterController>().enabled = false;
        transform.parent.GetComponentInChildren<Animator>().SetBool("jump", false);
        transform.parent.GetComponentInChildren<Animator>().SetBool("defeat", true);

        yield return new WaitForSeconds(2.4f);

        explosionPrefab.SetActive(true);
        bossModelObject.SetActive(false);
    }
}
