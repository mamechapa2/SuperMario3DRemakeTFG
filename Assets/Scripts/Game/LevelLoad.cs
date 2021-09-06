using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadLevel());
    }

    private IEnumerator loadLevel()
    {
        yield return new WaitForSeconds(2f);

        //Carga la escena, reinicia el tiempo y reactiva el timer
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameControl.internalTime = 300;
        GameControl.stopTimer = false;
    }
}
