using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    //Vidas
    public int startingLives = 3;
    private int internalLives;
    private GameObject livesDisplay;

    //Monedas
    private int internalCoins = 0;
    private GameObject coinsDisplay;

    //Estrellas
    private int internalStars = 0;
    private GameObject starsDisplay;

    //Timer
    public int startingTime = 300;
    private float internalTime;
    private GameObject timeDisplay;

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
    public void decreaseLives()
    {
        internalLives--;

        if(internalLives == 0)
        {
            //TODO FIN DE JUEGO
        }
    }

    public void increaseLives()
    {
        internalLives++;
    } 

    //Monedas
    public void decreaseCoins()
    {
        internalCoins--;
    }

    public void increaseCoins()
    {
        internalCoins++;
    }

    //Estrellas
    public void decreaseStars()
    {
        internalStars--;
    }

    public void increaseStars()
    {
        internalStars++;
    }

    private void updateTimer()
    {
        internalTime -= Time.deltaTime;
        if (internalTime < 0)
        {
            //TODO FIN DE JUEGO
        }
    }
}
