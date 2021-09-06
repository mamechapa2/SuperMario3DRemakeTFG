using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    private GameObject player;
    private bool end = false;
    private bool startedBefore = false;

    private GameObject cameraObject;

    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.FindGameObjectWithTag("SecondCamera").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Si ha llegado al final y no habia llegado antes
        if (end)
        {
            end = true;
            player.GetComponent<CharacterController>().Move(new Vector3(-1 * Time.deltaTime * 10, 0, 0));
            if (!startedBefore)
            {
                startedBefore = true;

                //Inicia la corutina para cambiar de nivel
                StartCoroutine(changeLevel());
            }
        }
    }

    private IEnumerator changeLevel()
    {
        //Activa la musica del final
        GameObject.Find("LevelEnd").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);

        //Desactiva el script de la camara
        cameraObject.GetComponent<CameraController3D>().enabled = false;
        
        //Actualiza el tamaño del score y suma el tiempo restante al mismo
        GameObject scoreDisplay = GameObject.Find("ScoreDisplay").gameObject;
        scoreDisplay.GetComponent<TextMeshProUGUI>().fontSize = 100;
        GameControl.addScore((int)GameControl.internalTime);

        yield return new WaitForSeconds(6f);

        //Carga la siguiente escena y reactiva los scripts
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        player.GetComponent<PlayerControllerCharacterController>().enabled = true;
        cameraObject.GetComponent<CameraController3D>().enabled = true;
        scoreDisplay.GetComponent<TextMeshProUGUI>().fontSize = 50;
        GameControl.levelStars = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GameObject.Find("LevelMusic").GetComponent<AudioSource>().Stop();
            end = true;
            player = other.gameObject;

            //Desactiva el script para controlar el personaje
            player.GetComponent<PlayerControllerCharacterController>().enabled = false;
            GameControl.stopTimer = true;
        }
    }
}
