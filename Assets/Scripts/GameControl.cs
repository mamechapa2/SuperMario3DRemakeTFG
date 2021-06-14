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

    // Start is called before the first frame update
    void Start()
    {
        internalLives = startingLives;
        livesDisplay = GameObject.Find("LivesDisplay").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        updateLivesDisplay();
    }

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

    private void updateLivesDisplay()
    {
        livesDisplay.GetComponent<Text>().text = "" + internalLives;
    }
}
