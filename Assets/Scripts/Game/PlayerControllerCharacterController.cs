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

    public Transform rotationPoint;
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
            moveDirection = ((transform.forward * -Input.GetAxis("Vertical")) + (transform.right * -Input.GetAxis("Horizontal"))) * runSpeed + transform.up * moveDirection.y;
            
            //moveDirection = new Vector3(-Input.GetAxis("Horizontal") * runSpeed, moveDirection.y, -Input.GetAxis("Vertical") * runSpeed);
        }
        else
        {
            moveDirection = new Vector3(-Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, -Input.GetAxis("Vertical") * moveSpeed);
        }
        //Ajustamos el movimiento del jugador en base a los ejes "Horizontal" y "Vertical"

        //Si esta en el suelo y se pulsa "Jump", ajustamos la direccion
        if (characterController.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        //Aplicamos la gravedad
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);

        //Mover al jugador en la direccion de la camara
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //    transform.rotation = Quaternion.Euler(0f, rotationPoint.transform.rotation.eulerAngles.y, 0f);
            Quaternion playerNewRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, playerNewRotation, rotationSpeed * Time.deltaTime); //Para realizar suave el movimiento
        }

        //Actualizar animaciones
        animator.SetBool("isGrounded", characterController.isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")));
    }
}
