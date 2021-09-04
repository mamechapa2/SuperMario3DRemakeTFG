using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCharacterController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float runSpeed = 10;
    public float jumpSpeed = 8.5f;
    private CharacterController characterController;

    private Vector3 moveDirection;
    public float gravityScale = 2;

    private Animator animator;

    public float rotationSpeed;

    public GameObject playerModel;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveWith3DCamera();
    }

    private void moveWith3DCamera()
    {
        if (Input.GetButton("Run"))
        {
            moveDirection = ((transform.right * -Input.GetAxis("Horizontal"))) * runSpeed + transform.up * moveDirection.y;
        }
        else
        {
            moveDirection = new Vector3(-Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, 0f);
        }

        if (characterController.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);


        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Quaternion playerNewRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, playerNewRotation, rotationSpeed * Time.deltaTime); //Para realizar suave el movimiento
        }

        animator.SetBool("isGrounded", characterController.isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")));
    }
}
