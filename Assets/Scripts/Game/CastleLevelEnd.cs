using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleLevelEnd : MonoBehaviour
{
    private GameObject player;
    private bool end = false;
    private bool startedBefore = false;

    // Update is called once per frame
    void Update()
    {
        //Si se ha llegado al final y no se habia llegado antes
        if (end)
        {
            end = true;
            if (!startedBefore)
            {
                startedBefore = true;
                StartCoroutine(changeLevel());
            }
        }
    }

    private IEnumerator changeLevel()
    {
        //Reproducir la musica del final del nivel
        GameObject.Find("LevelEnd").GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2f);

        //Poner el score mas grande y añadir el tiempo restante como puntuacion
        GameObject.Find("ScoreDisplay").gameObject.GetComponent<TextMeshProUGUI>().fontSize = 100;
        GameControl.addScore((int)GameControl.internalTime);

        yield return new WaitForSeconds(6f);

        //Cargar la siguiente escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //Devolver el score a su tamaño
        GameObject.Find("ScoreDisplay").gameObject.GetComponent<TextMeshProUGUI>().fontSize = 50;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Parar la musica del nivel
            GameObject.Find("LevelMusic").GetComponent<AudioSource>().Stop();

            //Activar el final
            end = true;

            player = other.gameObject;

            //Parar el tiempo
            GameControl.stopTimer = true;
        }
    }
}
