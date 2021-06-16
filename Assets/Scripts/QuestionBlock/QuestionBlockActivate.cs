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
        if (other.gameObject.tag.Equals("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            Debug.Log("QuestionBlockActivate::OnTriggerEnter: activado");
            block.SetActive(false);
            deadBlock.SetActive(true);
            mushroom.SetActive(true);

            StartCoroutine(stopObjectAnimation());
        }
    }
    private IEnumerator stopObjectAnimation()
    {
        yield return new WaitForSeconds(0.99f);
        mushroom.GetComponentInChildren<Animator>().enabled = false;
    }
}
