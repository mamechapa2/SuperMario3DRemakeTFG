using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaRightTrigger : MonoBehaviour
{
    public Rigidbody rb;
    public bool goLeft = false;
    public GameObject leftTrigger;


    public float moveSpeed = 18;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goLeft)
        {
            //goLeft = false;
            rb.velocity = new Vector3(1 * moveSpeed, -9, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("RIGHT COLISION CON: " + other.name);
        switch (other.tag)
        {
            case "Enemy":
                Destroy(other.transform.parent.transform.parent.gameObject);
                break;
            case "Player":
                goLeft = true;
                leftTrigger.GetComponent<KoopaLeftTrigger>().goRight = false;
                break;
            default:
                goLeft = true;
                leftTrigger.GetComponent<KoopaLeftTrigger>().goRight = false;
                break;

        }
    }
}
