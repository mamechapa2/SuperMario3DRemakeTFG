using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeUse : MonoBehaviour
{
    private GameObject player;
    private bool playerAtTop = false;
    private bool usingPipe = false;
    private bool used = false;

    public Animator colliderAnimator;
    public GameObject exit;

    private Animator fadeScreen;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fadeScreen = GameObject.Find("Fadescreen").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !usingPipe)
        {
            if (playerAtTop && !used)
            {
                used = true;
                GameControl.setUsingPipe(true);
                StartCoroutine(usePipe());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")){
            Debug.Log("PipeUse::OnTriggerEnter");
            playerAtTop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("PipeUse::OnTriggerExit");
            playerAtTop = false;
        }
    }

    private IEnumerator usePipe()
    {
        //Posicionamos el jugador y activamos las animaciones
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z); //Centrar al jugador
        usingPipe = true; //Control de uso
        colliderAnimator.enabled = true; //Activar animator
        fadeScreen.enabled = true;

        yield return new WaitForSeconds(1f); //Esperamos un segundo para las animaciones

        //Mover al jugador a la salida (desactivando su controlador)
        player.GetComponent<CharacterController>().enabled = false; //Desactivar control del jugador
        player.transform.position = exit.transform.position; //Mover al jugador a la salida
        player.GetComponent<CharacterController>().enabled = true; //Devolver control al jugador

        yield return new WaitForSeconds(1f); //Esperamos un segundo para las animaciones
        fadeScreen.enabled = false;
        colliderAnimator.enabled = false;

        usingPipe = false;
        GameControl.setUsingPipe(false);
    }
}
