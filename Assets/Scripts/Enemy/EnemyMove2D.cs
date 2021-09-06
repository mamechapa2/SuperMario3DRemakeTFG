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

    public bool direction = true;

    private void Start()
    {
        //Obtenemos los puntos izquierdo y derecho
        internalResetPointRight = resetPointRighta.transform.position.x;
        internalResetPointLeft = resetPointLefta.transform.position.x;
    }
    void Update()
    {
        currentPoint = transform.position.x;

        //Modificamos hacia donde mira el enemigo en funcion de para donde se esta movimiendo
        if (direction)
        {
            transform.LookAt(resetPointRighta.transform.position);
        }
        else
        {
            transform.LookAt(resetPointLefta.transform.position);
        }

        //Si llega a uno de los extremos, cambiamos la direccion del movimiento
        if (currentPoint > internalResetPointRight)
        {
            direction = false;
        }

        if (currentPoint < internalResetPointLeft)
        {
            direction = true;
        }

        //Movemos el enemigo
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnColliderEnter(Collider other)
    {
        //Si el enemigo choca contra otro enemigo o cualquier otro objeto, se da la vuelta
        if (!other.tag.Equals("Player"))
        {
            direction = !direction;
        }
    }
}
