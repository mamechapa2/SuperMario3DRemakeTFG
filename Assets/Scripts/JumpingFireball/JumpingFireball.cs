using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingFireball : MonoBehaviour
{
    private Rigidbody rb;

    private bool jump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump)
        {
            jump = false;

            rb.velocity = new Vector3(0, 15, 0);

            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(4f);
        jump = true;
    }
}
