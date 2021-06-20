using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockActivate : MonoBehaviour
{
    public GameObject block;
    public GameObject deadBlock;
    public GameObject mushroom;

    public Animator blockAnimator;

    public bool containsMushroom = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (containsMushroom)
            {
                GetComponent<BoxCollider>().enabled = false;
                block.SetActive(false);
                deadBlock.SetActive(true);
                mushroom.SetActive(true);
                GameObject.Find("PowerUpAppears").GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
                block.SetActive(false);
                deadBlock.SetActive(true);
                GameControl.increaseCoins();
            }

            StartCoroutine(stopObjectAnimation());
        }
    }
    private IEnumerator stopObjectAnimation()
    {
        yield return new WaitForSeconds(0.99f);
        mushroom.GetComponentInChildren<Animator>().enabled = false;
    }
}
