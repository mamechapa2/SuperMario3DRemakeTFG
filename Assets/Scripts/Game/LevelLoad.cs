using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    private GameObject orthographicCamera;
    private GameObject perspectiveCamera;
    // Start is called before the first frame update
    void Start()
    {
        orthographicCamera = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        perspectiveCamera = GameObject.FindGameObjectWithTag("SecondCamera").gameObject;
        StartCoroutine(loadLevel());
    }

    private IEnumerator loadLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameControl.internalTime = 300;
        GameControl.stopTimer = false;
        if (!GameControl.isOrthographic())
        {
            orthographicCamera.GetComponent<Camera>().enabled = !orthographicCamera.GetComponent<Camera>().enabled;
            GameControl.orthographic = true;
            perspectiveCamera.GetComponent<Camera>().enabled = !perspectiveCamera.GetComponent<Camera>().enabled;
        }
    }
}
