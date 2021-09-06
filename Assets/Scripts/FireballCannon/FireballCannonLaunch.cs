using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCannonLaunch : MonoBehaviour
{
    public GameObject prefab;
    public Transform position;

    private bool create = true;
    // Update is called once per frame
    void Update()
    {
        //Si tiene que lanzar una bola, inicia la corutina
        if (create)
        {
            StartCoroutine(instantiatePrefab());
        }
    }

    private IEnumerator instantiatePrefab()
    {
        create = false;

        //Instancia el prefab
        Instantiate(prefab, position);
        yield return new WaitForSeconds(5f);

        create = true;
    }
}
