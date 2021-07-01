using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroomPickUp : MonoBehaviour
{
    public GameObject mushroom;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            mushroom.SetActive(false);
            GameControl.powerUpCollect();
        }
    }
}
