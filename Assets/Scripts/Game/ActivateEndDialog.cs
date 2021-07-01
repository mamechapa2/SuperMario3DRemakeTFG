using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEndDialog : MonoBehaviour
{
    public GameObject dialogObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        dialogObject.SetActive(true);
    }
}
