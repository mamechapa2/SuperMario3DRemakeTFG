using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public Vector3 offset; //Distancia al jugador
    public bool useOffset = false;

    public float rotationSpeed;
    public Transform rotationPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (!useOffset)
        {
            offset = player.transform.position - transform.position;
        }

        rotationPoint.transform.position = player.transform.position;
        rotationPoint.transform.parent = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Girar el jugador hacia donde mira la camara
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        player.transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;
        player.transform.Rotate(-vertical, 0, 0);

        //Mover la camara
        float desiredYAngle = player.transform.eulerAngles.y;
        float desiredXAngle = player.transform.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = player.transform.position - (rotation * offset);

        //transform.position = (player.transform.position - offset);
        transform.LookAt(player.transform);
    }
}
