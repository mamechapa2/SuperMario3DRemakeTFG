using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
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

    //LevelControl
    public int numMaxLevel;
    public int numWorlds;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();
        updateDisplays();
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

    private static void updateTimer()
    {
        internalTime -= Time.deltaTime;
        if (internalTime < 0)
        {
            //TODO FIN DE JUEGO
        }
    }
}
