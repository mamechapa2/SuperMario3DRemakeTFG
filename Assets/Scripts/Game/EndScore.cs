using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public int score;
    public int displayScore;
    private GameObject scoreUI;
    void Start()
    {
        score = 0;
        displayScore = 0;
        scoreUI = GameObject.Find("StarsDisplay").gameObject;

        StartCoroutine(updateScore());
    }
    private IEnumerator updateScore()
    {
        while (true)
        {
            if (displayScore < score)
            {
                displayScore++;
                scoreUI.GetComponent<Text>().text = displayScore.ToString(); 
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
