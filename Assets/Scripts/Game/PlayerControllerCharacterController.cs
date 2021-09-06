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
            moveDirection = ((transform.right * -Input.GetAxis("Horizontal"))) * runSpeed + transform.up * moveDirection.y; //Movimiento corriendo
        }
        else
        {
            moveDirection = new Vector3(-Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, 0f); //Movimiento normal
        }

        if (characterController.isGrounded) //Si esta en el suelo
        {
            moveDirection.y = 0f;
            if (Input.GetButton("Jump")) //Y pulsa saltar
            {
                moveDirection.y = jumpSpeed; //Realiza el salto actualizando el vector de movimiento
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime); //Añadimos la gravedad
        characterController.Move(moveDirection * Time.deltaTime);

        //Girar el modelo del personaje segun la direccion
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Quaternion playerNewRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, playerNewRotation, rotationSpeed * Time.deltaTime); //Para realizar suave el movimiento
        }

        //Activar las animaciones
        animator.SetBool("isGrounded", characterController.isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")));
    }
}
