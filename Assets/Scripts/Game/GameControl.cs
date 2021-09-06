using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl : MonoBehaviour
{
    private static GameObject player;

    //Variables necesarias para el control del juego
    //Vidas
    public static int startingLives = 3;
    private static int internalLives;
    private GameObject livesDisplay;

    //Monedas
    private static int internalCoins;
    private GameObject coinsDisplay;

    //Estrellas
    private static int internalStars;
    private GameObject starsDisplay;
    public static int levelStars;

    //Timer
    public int startingTime = 300;
    public static float internalTime;
    private GameObject timeDisplay;
    private bool warning = false;
    public static bool stopTimer = false;

    //Powerup
    public bool bigMario = false;
    private static bool internalBigMario;
    private static bool makeMarioBigger = false;
    private static bool makeMarioSmall = false;

    //Pipe
    private static bool usingPipe = false;

    //Score
    private static int score = 0;
    private int displayScore = 0;
    private GameObject scoreUI;
    
    //Control
    private static bool restart = false;
    private static bool endGame = false;

    //DontDestroy
    private static GameControl gameControl = null;
    private void Awake()
    {
        //Destruye otros objetos iguales a este, se queda con el primero de ellos
        if (gameControl == null)
        {
            gameControl = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (gameControl != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        
        //Vidas
        livesDisplay = GameObject.Find("LivesDisplay").gameObject;
        internalLives = startingLives;

        //Monedas
        coinsDisplay = GameObject.Find("CoinsDisplay").gameObject;
        internalCoins = 0;

        //Estrellas
        starsDisplay = GameObject.Find("StarsDisplay").gameObject;
        internalStars = 0;
        levelStars = 0;

        //Timer
        internalTime = startingTime;
        timeDisplay = GameObject.Find("TimeDisplay").gameObject;

        //Score
        scoreUI = GameObject.Find("ScoreDisplay").gameObject;
        scoreUI.GetComponent<TextMeshProUGUI>().text = displayScore.ToString();
        scoreUI.GetComponent<TextMeshProUGUI>().text = displayScore.ToString();
        StartCoroutine(updateScore());

        //Powerup
        internalBigMario = bigMario;
        makeMarioBigger = bigMario;
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizar timer
        if (!stopTimer)
        {
            updateTimer();
        }

        //Actualizar interfaz y la escala de Mario, si recogio powerup o lo perdio
        updateDisplays();
        updateMarioScale();

        //Si el juego ha acabado, inicia la corutina (perdido todas las vidas)
        if (endGame)
        {
            endGame = false;
            StartCoroutine(restartGame());
        }

        //Si ha perdido una unica vida, pero el juego continua
        if (restart)
        {
            restart = false;
            StartCoroutine(restartLevel());
        }
    }

    //Actualiza la interfaz
    private void updateDisplays()
    {
        livesDisplay.GetComponent <TextMeshProUGUI>().text = "" + internalLives;
        coinsDisplay.GetComponent<TextMeshProUGUI>().text = "" + internalCoins;
        starsDisplay.GetComponent<TextMeshProUGUI>().text = "" + internalStars;
        timeDisplay.GetComponent<TextMeshProUGUI>().text = "" + (int)internalTime;
    }

    //Reinicia por completo el juego
    private IEnumerator restartGame()
    {
        player.GetComponent<PlayerControllerCharacterController>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;

        GameControl.score = 0;

        GameObject.Find("LevelMusic").GetComponent<AudioSource>().Stop();
        player.GetComponentInChildren<Animator>().SetBool("die", true);
        GameObject.Find("GameOver").GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(3.7f);

        SceneManager.LoadScene(1);
    }

    //Reinicia el nivel
    private IEnumerator restartLevel()
    {
        stopTimer = true;

        player.GetComponent<PlayerControllerCharacterController>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;

        player.GetComponentInChildren<Animator>().SetBool("die", true);
        GameObject.Find("LevelMusic").GetComponent<AudioSource>().Stop();
        GameObject.Find("Death").GetComponent<AudioSource>().Play();
        internalStars -= levelStars;

        yield return new WaitForSeconds(2.7f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        player.GetComponentInChildren<Animator>().SetBool("die", false);

        player.GetComponent<PlayerControllerCharacterController>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
    }

    //Vidas
    public static void decreaseLives()
    {
        internalLives--;

        if (internalLives <= 0)
        {
            endGame = true;
        }
        else
        {
            restart = true;
        }
    }

    public static void increaseLives()
    {
        internalLives++;
        GameControl.addScore(150);
        GameObject.Find("GreenMushroomPickUp").GetComponent<AudioSource>().Play();
    } 

    //Monedas
    public static void decreaseCoins()
    {
        internalCoins--;
    }

    public static void increaseCoins()
    {
        internalCoins++;
        GameControl.addScore(100);
        if (internalCoins == 100)
        {
            internalCoins = 0;
            increaseLives();
        }
        GameObject.Find("CoinPickUp").GetComponent<AudioSource>().Play();
    }

    //Estrellas
    public static void decreaseStars()
    {
        internalStars--;
    }

    public static void increaseStars()
    {
        internalStars++;
        levelStars++;
        GameControl.addScore(200);
        GameObject.Find("StarPickUp").GetComponent<AudioSource>().Play();
    }

    //Timer
    private void updateTimer()
    {
        internalTime -= Time.deltaTime;
        if (internalTime < 0)
        {
            stopTimer = true;
            decreaseLives();
            GameObject.Find("Death").GetComponent<AudioSource>().Play();
        }

        if(internalTime < startingTime / 2 && !warning)
        {
            warning = true;
            GameObject.Find("TimeWarning").GetComponent<AudioSource>().Play();
        }
    }

    //Powerup
    public static void powerUpCollect()
    {
        if (internalBigMario)
        {
            increaseLives();
        }
        else
        {
            GameControl.addScore(50);
            internalBigMario = true;
            makeMarioBigger = true;
            GameObject.Find("RedMushroomPickUp").GetComponent<AudioSource>().Play();
        }
    }

    private IEnumerator powerUpCollectAnimation()
    {
        player.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    public static void damageReceived()
    {
        if (internalBigMario)
        {
            internalBigMario = false;
            makeMarioSmall = true;            
        }
        else
        {
            decreaseLives();
        }
    }

    private IEnumerator damageReceivedAnimation()
    {
        GameObject.Find("PipeEntry").GetComponent<AudioSource>().Play();
        player.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        yield return new WaitForSeconds(0.05f);
        player.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }

    public static bool isBigMario()
    {
        return internalBigMario;
    }

    private void updateMarioScale()
    {
        if (makeMarioBigger)
        {
            StartCoroutine(powerUpCollectAnimation());
            makeMarioBigger = false;
        }

        if (makeMarioSmall)
        {
            StartCoroutine(damageReceivedAnimation());
            makeMarioSmall = false;
        }
    }

    //Pipe
    public static void setUsingPipe(bool isUsing)
    {
        usingPipe = isUsing;
        if (usingPipe)
        {
            GameObject.Find("PipeEntry").GetComponent<AudioSource>().Play();
        }
    }

    public static bool isUsingPipe()
    {
        return usingPipe;
    }

    //Score
    private IEnumerator updateScore()
    {
        while (true)
        {
            if (displayScore < score)
            {
                displayScore++;
                scoreUI.GetComponent<TextMeshProUGUI>().text = displayScore.ToString();
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    public static void addScore(int points)
    {
        score += points;
    }

    //Reset
    public static void resetGame()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;

        //Vidas
        internalLives = startingLives;

        //Monedas
        internalCoins = 0;

        //Estrellas
        internalStars = 0;

        //Timer
        internalTime = 300;

        //Score
        score = 0;

        //Powerup
        internalBigMario = false;
    }
}
