using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlockBreak : MonoBehaviour
{
    public GameObject brick;
    public GameObject breakBrick;
    public BoxCollider collider;

    public bool containsCoin = false;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
        collider.enabled = false;
        brick.SetActive(false);
        breakBrick.SetActive(true);
        if (containsCoin)
        {
            GameControl.increaseCoins();
        }
        StartCoroutine(destroyBlock());
    }

    private IEnumerator destroyBlock()
    {
        yield return new WaitForSeconds(1.13f);
        breakBrick.SetActive(false);
    }
}
