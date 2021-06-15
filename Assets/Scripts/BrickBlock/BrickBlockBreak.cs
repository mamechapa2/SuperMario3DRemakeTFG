using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlockBreak : MonoBehaviour
{
    public GameObject brick;
    public GameObject breakBrick;

    public bool containsCoin = false;
    private void OnTriggerEnter(Collider other)
    {
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
