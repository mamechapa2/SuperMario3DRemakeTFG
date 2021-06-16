using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float offsetX = 0;
    public float offsetY = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCC").gameObject;
        transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, transform.position.z);
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y, transform.position.z);
    }
}
