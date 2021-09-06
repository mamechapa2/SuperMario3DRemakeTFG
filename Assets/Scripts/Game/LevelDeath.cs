using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //Si Mario tiene un powerup le quita dos vidas, sino solo una
            if (GameControl.isBigMario())
            {
                GameControl.damageReceived();
            }

            GameControl.damageReceived();
        }
    }
}
