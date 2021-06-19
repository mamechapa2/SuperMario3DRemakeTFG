using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private GameObject player;
    private bool end = false;
    private bool startedBefore = false;

    private GameObject orthographicCamera;
    private GameObject perspectiveCamera;

    public int nextScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        orthographicCamera = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        perspectiveCamera = GameObject.FindGameObjectWithTag("SecondCamera").gameObject;
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
        orthographicCamera.GetComponent<CameraControllerOrthographic>().enabled = false;
        yield return new WaitForSeconds(4.3f);
        SceneManager.LoadScene(nextScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            end = true;
            player = other.gameObject;
            player.GetComponent<PlayerControllerCharacterController>().enabled = false;
            if (!GameControl.isOrthographic())
            {
                orthographicCamera.GetComponent<Camera>().enabled = !orthographicCamera.GetComponent<Camera>().enabled;
                GameControl.orthographic = true;
                perspectiveCamera.GetComponent<Camera>().enabled = !perspectiveCamera.GetComponent<Camera>().enabled;
            }
        }
    }
}