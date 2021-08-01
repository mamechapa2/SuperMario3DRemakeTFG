using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaLeftTrigger : MonoBehaviour
{
    public Rigidbody rb;
    public bool goRight = false;
    public GameObject rightTrigger;

    public float moveSpeed = 18;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goRight)
        {
            //goRight = true;
            rb.velocity = new Vector3(-1 * moveSpeed, -9, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("LEFT COLISION CON : " + other.name);
        switch (other.tag)
        {
            case "Enemy":
                Destroy(other.transform.parent.transform.parent.gameObject);
                break;
            case "Player":
                goRight = true;
                rightTrigger.GetComponent<KoopaRightTrigger>().goLeft = false;
                break;
            default:
                goRight = true;
                rightTrigger.GetComponent<KoopaRightTrigger>().goLeft = false;
                break;

        }
    }
}
