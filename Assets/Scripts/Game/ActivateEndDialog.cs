using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEndDialog : MonoBehaviour
{
    public GameObject dialogObject;
    private void OnTriggerEnter(Collider other)
    {
        dialogObject.SetActive(true);
    }
}
