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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        //SEGUIR LLORANDO CON ESTO
        //ACTIVAR BIEN EL ANIMATOR
        Debug.Log("PipeUse::usePipe: inicio");
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z); //Centrar al jugador
        usingPipe = true; //Control de uso
        colliderAnimator.enabled = true; //Activar animator

        yield return new WaitForSeconds(1f);

        player.GetComponent<CharacterController>().enabled = false; //Desactivar control del jugador
        player.transform.position = exit.transform.position; //Mover al jugador a la salida
        player.GetComponent<CharacterController>().enabled = true; //Devolver control al jugador

        yield return new WaitForSeconds(1f);

        colliderAnimator.enabled = false;

        Debug.Log("PipeUse::usePipe: tp");

        usingPipe = false;
        GameControl.setUsingPipe(false);
    }
}
