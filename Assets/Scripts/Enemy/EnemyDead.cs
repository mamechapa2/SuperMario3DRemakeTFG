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
            goombaObject.GetComponentInChildren<Animator>().enabled = false;
            GameObject.Find("EnemyDead").GetComponent<AudioSource>().Play();
            GetComponent<BoxCollider>().enabled = false;
            GetComponentInParent<EnemyMove2D>().enabled = false;
            goombaObject.GetComponentInChildren<EnemyMakeDamage>().enabled = false;
            makeDamageTrigger.SetActive(false);
            goombaObject.transform.localScale = new Vector3(1, 0.5f, 1);
            goombaObject.transform.position = new Vector3(goombaObject.transform.position.x, goombaObject.transform.position.y - 0.5f, goombaObject.transform.position.z);
            StartCoroutine(disappear());
        }
    }

    private IEnumerator disappear()
    {
        yield return new WaitForSeconds(2f);
        goombaObject.SetActive(false);
    }
}
