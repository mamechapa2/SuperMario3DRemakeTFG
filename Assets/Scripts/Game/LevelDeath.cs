using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (GameControl.isBigMario())
            {
                GameControl.damageReceived();
            }

            GameControl.damageReceived();
        }
    }
}
