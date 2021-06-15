using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockActivate : MonoBehaviour
{
    public GameObject block;
    public GameObject deadBlock;
    public GameObject mushroom;

    public Animator blockAnimator;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GameControl.isBigMario())
        {
            GetComponent<BoxCollider>().enabled = false;
            Debug.Log("QuestionBlockActivate::OnTriggerEnter: bigmario");
            block.SetActive(false);
            deadBlock.SetActive(true);
            mushroom.SetActive(true);

            StartCoroutine(stopObjectAnimation());
        }
        else
        {
            blockAnimator.SetBool("bounce", true);
            StartCoroutine(stopBouncing());
            Debug.Log("QuestionBlockActivate::OnTriggerEnter: no bigmario");
        }
    }

    private IEnumerator stopObjectAnimation()
    {
        yield return new WaitForSeconds(0.99f);
        mushroom.GetComponentInChildren<Animator>().enabled = false;
    }

    private IEnumerator stopBouncing()
    {
        yield return new WaitForSeconds(0.18f);
        blockAnimator.SetBool("bounce", false);
    }
}
