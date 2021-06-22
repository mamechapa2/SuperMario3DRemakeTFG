using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = transform.position;
        player.GetComponent<CharacterController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
