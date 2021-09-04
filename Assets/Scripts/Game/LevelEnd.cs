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
        if (end)
        {
            end = true;
            player.GetComponent<CharacterController>().Move(new Vector3(-1 * Time.deltaTime * 10, 0, 0));
            if (!startedBefore)
            {
                startedBefore = true;
                StartCoroutine(changeLevel());
            }
        }
    }

    private IEnumerator changeLevel()
    {
        GameObject.Find("LevelEnd").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        cameraObject.GetComponent<CameraController3D>().enabled = false;
        GameObject scoreDisplay = GameObject.Find("ScoreDisplay").gameObject;
        //scoreDisplay.transform.localPosition = new Vector3(0, -6, 0);
        scoreDisplay.GetComponent<TextMeshProUGUI>().fontSize = 100;
        GameControl.addScore((int)GameControl.internalTime);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        player.GetComponent<PlayerControllerCharacterController>().enabled = true;
        cameraObject.GetComponent<CameraController3D>().enabled = true;
        //scoreDisplay.transform.localPosition = new Vector3(0, -60, 0);
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
            player.GetComponent<PlayerControllerCharacterController>().enabled = false;
            GameControl.stopTimer = true;
        }
    }
}
