using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2D : MonoBehaviour
{
    public float speed = 2;

    private float internalResetPointRight = 0;
    private float internalResetPointLeft = 0;

    public GameObject resetPointRighta;
    public GameObject resetPointLefta;

    private float currentPoint;
    private int direction = 1;
    // Update is called once per frame

    private void Start()
    {
        internalResetPointRight = resetPointRighta.transform.position.x;
        internalResetPointLeft = resetPointLefta.transform.position.x;
        transform.LookAt(resetPointRighta.transform.position);
    }
    void Update()
    {
        currentPoint = transform.position.x;

        if (direction == 1)
        {
            Debug.Log("Left");
            transform.LookAt(resetPointRighta.transform.position);
        }
        else
        {
            Debug.Log("Right");
            transform.LookAt(resetPointLefta.transform.position);
        }

        if (currentPoint > internalResetPointRight)
        {
            Debug.Log("Cambio a right");
            direction = 0;
        }

        if (currentPoint < internalResetPointLeft)
        {
            Debug.Log("Cambio a left");
            direction = 1;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
