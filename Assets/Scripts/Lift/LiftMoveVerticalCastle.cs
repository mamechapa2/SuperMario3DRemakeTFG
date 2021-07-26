using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMoveVerticalCastle : MonoBehaviour
{
    public float speed = 2;

    private float internalResetPointTop = 0;
    private float internalResetPointBot = 0;

    public GameObject resetPointTopa;
    public GameObject resetPointBota;

    private float currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        internalResetPointTop = resetPointTopa.transform.position.y;
        internalResetPointBot = resetPointBota.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentPoint = transform.position.y;

        if (currentPoint < internalResetPointBot)
        {
            transform.position = new Vector3(transform.position.x, internalResetPointTop, transform.position.z);
        }

        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
