using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private static GameObject player;
    //Vidas
    public int startingLives = 3;
    private static int internalLives;
    private GameObject livesDisplay;

    //Monedas
    private static int internalCoins = 0;
    private GameObject coinsDisplay;

    //Estrellas
    private static int internalStars = 0;
    private GameObject starsDisplay;

    //Timer
    public int startingTime = 300;
    private static float internalTime;
    private GameObject timeDisplay;

    //Powerup
    public bool bigMario = false;
    private static bool internalBigMario;
    private static bool aumentarMario = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        //Vidas
        internalLives = startingLives;
        livesDisplay = GameObject.Find("LivesDisplay").gameObject;

        //Monedas
        coinsDisplay = GameObject.Find("CoinsDisplay").gameObject;

        //Estrellas
        starsDisplay = GameObject.Find("StarsDisplay").gameObject;

        //Timer
        internalTime = startingTime;
        timeDisplay = GameObject.Find("TimeDisplay").gameObject;

        //Powerup
        internalBigMario = bigMario;
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();
        updateDisplays();
        if (aumentarMario)
        {
            StartCoroutine(animacionPowerUp());
            aumentarMario = false;
        }
    }

    private void updateDisplays()
    {
        livesDisplay.GetComponent<Text>().text = "" + internalLives;
        coinsDisplay.GetComponent<Text>().text = "" + internalCoins;
        starsDisplay.GetComponent<Text>().text = "" + internalStars;
        timeDisplay.GetComponent<Text>().text = "" + (int)internalTime;
    }

    //Vidas
    public static void decreaseLives()
    {
        internalLives--;

        if (internalLives == 0)
        {
            //TODO FIN DE JUEGO
            Debug.Log("FIN DEL JUEGO");
        }
    }

    public static void increaseLives()
    {
        internalLives++;
    } 

    //Monedas
    public static void decreaseCoins()
    {
        internalCoins--;
    }

    public static void increaseCoins()
    {
        internalCoins++;
    }

    //Estrellas
    public static void decreaseStars()
    {
        internalStars--;
    }

    public static void increaseStars()
    {
        internalStars++;
    }

    //Timer
    private static void updateTimer()
    {
        internalTime -= Time.deltaTime;
        if (internalTime < 0)
        {
            //TODO FIN DE JUEGO
        }
    }

    //Powerup
    public static void powerUpCollect()
    {
        internalBigMario = true;
        aumentarMario = true;
        Debug.Log("GameControl::powerUpCollect");
    }

    private IEnumerator animacionPowerUp()
    {
        player.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(1, 1, 1);
    }

    public static void damageReceived()
    {
        if (internalBigMario)
        {
            internalBigMario = false;
            Debug.Log("GameControl::damageReceived: powerup perdido");
            //TODO CAMBIAR ESCALA DEL PERSONAJE
            player.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        else
        {
            Debug.Log("GameControl::damageReceived: reiniciar");
            SceneManager.LoadScene(0);
        }
    }

    public static bool isBigMario()
    {
        return internalBigMario;
    }
}
