using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowserJrCharacterController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private bool jumping = false;

    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        moveDirection = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!jumping)
        {
            StartCoroutine(jump());
        }
    }

    private IEnumerator jump()
    {
        jumping = true;
        animator.SetBool("jump", true);
        yield return new WaitForSeconds(1f);
        rb.velocity = new Vector3(0, 10, 0);
        yield return new WaitForSeconds(2f);
        animator.SetBool("jump", false);
        jumping = false;
    }
}
