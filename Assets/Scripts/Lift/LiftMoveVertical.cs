using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMoveVertical : MonoBehaviour
{
    public float speed = 2;

    private float internalResetPointTop = 0;
    private float internalResetPointBot = 0;

    public GameObject resetPointTopa;
    public GameObject resetPointBota;

    private float currentPoint;

    public bool direction = true;
    // Start is called before the first frame update
    void Start()
    {
        internalResetPointTop = resetPointTopa.transform.position.y;
        internalResetPointBot = resetPointBota.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionVector;
        if (direction)
        {
            directionVector = Vector3.down * Time.deltaTime * speed;
        }
        else
        {
            directionVector = Vector3.up * Time.deltaTime * speed;
        }

        currentPoint = transform.position.y;
        if (currentPoint > internalResetPointTop)
        {
            direction = true;
        }

        if (currentPoint < internalResetPointBot)
        {
            direction = false;
        }

        transform.Translate(directionVector);
    }
}
