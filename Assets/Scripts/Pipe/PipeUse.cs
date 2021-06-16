using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeUse : MonoBehaviour
{
    private GameObject player;
    private bool playerAtTop = false;
    private bool usingPipe = false;

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
            if (playerAtTop)
            {
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
        Debug.Log("PipeUse::usePipe");
        
        usingPipe = true; //Control de uso
        colliderAnimator.enabled = true; //Activar animator

        player.transform.position = transform.position; //Centrar al jugador
        //player.GetComponent<CharacterController>().enabled = false; //Desactivar control del jugador

        yield return new WaitForSeconds(2f);
        
        player.transform.position = exit.transform.position; //Mover al jugador a la salida
        //player.GetComponent<CharacterController>().enabled = true; //Devolver control al jugador

        yield return new WaitForSeconds(0.01f);
        colliderAnimator.enabled = false;

        usingPipe = false;
    }
}
