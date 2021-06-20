using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScore : MonoBehaviour
{
    //You need a variable for the actual score
    public int score;
    //And you also need a variable that holds the increasing score number, let's call it display score
    public int displayScore;
    //Variable for the UI Text that will show the score
    public Text scoreUI;
    void Start()
    {
        //Both scores start at 0
        score = 0;
        displayScore = 0;
        StartCoroutine(ScoreUpdater());
    }
    private IEnumerator ScoreUpdater()
    {
        while (true)
        {
            if (displayScore < score)
            {
                displayScore++; //Increment the display score by 1
                scoreUI.text = displayScore.ToString(); //Write it to the UI
            }
            yield return new WaitForSeconds(0.2f); // I used .2 secs but you can update it as fast as you want
        }
    }
}
