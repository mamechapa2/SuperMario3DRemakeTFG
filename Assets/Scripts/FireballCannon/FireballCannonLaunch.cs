using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCannonLaunch : MonoBehaviour
{
    public GameObject prefab;
    public Transform position;

    private bool create = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (create)
        {
            StartCoroutine(instantiatePrefab());
        }
    }

    private IEnumerator instantiatePrefab()
    {
        create = false;
        Instantiate(prefab, position);

        yield return new WaitForSeconds(5f);

        create = true;
    }
}
