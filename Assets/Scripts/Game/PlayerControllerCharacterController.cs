using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCharacterController : MonoBehaviour
{
    public float moveSpeed = 10;
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
        //Ajustamos el movimiento del jugador en base a los ejes "Horizontal" y "Vertical"
        
        //float moveDirectionY = moveDirection.y;
        moveDirection = new Vector3(-Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, 0f);
        //moveDirection.x = (transform.position.x + Input.GetAxisRaw("Vertical"));
        //moveDirection = moveDirection.normalized * moveSpeed;
        //moveDirection.y = moveDirectionY; 

        //Si esta en el suelo y se pulsa "Jump", ajustamo la direccion
        if (characterController.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
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
            Quaternion playerNewRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, 0f));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, playerNewRotation, rotationSpeed * Time.deltaTime); //Para realizar suave el movimiento
        }

        animator.SetBool("isGrounded", characterController.isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
}
