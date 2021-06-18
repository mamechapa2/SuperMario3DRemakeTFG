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
        if (GameControl.isBigMario())
        {
            GetComponent<BoxCollider>().enabled = false;
            colliderBrick.enabled = false;
            brick.SetActive(false);
            breakBrick.SetActive(true);
            if (containsCoin)
            {
                GameControl.increaseCoins();
            }
            StartCoroutine(destroyBlock());
        }
        else
        {
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
