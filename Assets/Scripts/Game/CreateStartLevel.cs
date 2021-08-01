using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStartLevel : MonoBehaviour
{
    public int levelLenght = 6;
    public int numPrefabs;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        createRandomLevel();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = transform.position;
        player.GetComponent<CharacterController>().enabled = true;
    }

    private void createRandomLevel()
    {
        Random.InitState(System.DateTime.Now.Millisecond + System.DateTime.Now.Minute);

        Vector3 pos = new Vector3(0, 0, 0);
        int randomNumberPrefab;
        int lastRandomNumber = 0;

        for (int i = 0; i < levelLenght; i++)
        {
            do
            {
                randomNumberPrefab = Random.Range(1, numPrefabs + 1);
            } while (lastRandomNumber == randomNumberPrefab);

            Instantiate(Resources.Load(randomNumberPrefab.ToString()), pos, Quaternion.identity);
            pos.x += -10;

            lastRandomNumber = randomNumberPrefab;
        }

        Instantiate(Resources.Load("LevelEnd"), pos, Quaternion.identity);
    }
}
