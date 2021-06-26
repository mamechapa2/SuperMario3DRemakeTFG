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

    [Header("Tick: right | Untick: left")]
    public bool direction = true;

    private void Start()
    {
        internalResetPointRight = resetPointRighta.transform.position.x;
        internalResetPointLeft = resetPointLefta.transform.position.x;
    }
    void Update()
    {
        currentPoint = transform.position.x;

        if (direction)
        {
            transform.LookAt(resetPointRighta.transform.position);
        }
        else
        {
            transform.LookAt(resetPointLefta.transform.position);
        }

        if (currentPoint > internalResetPointRight)
        {
            direction = false;
        }

        if (currentPoint < internalResetPointLeft)
        {
            direction = true;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnColliderEnter(Collider other)
    {
        Debug.Log("ASDASDASDASDASDASDASDASDADADA");
        if (!other.tag.Equals("Player"))
        {
            Debug.Log(other.name);
            direction = !direction;
        }
    }
}
