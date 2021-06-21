using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy gameControl;
    private void Awake()
    {
        if (gameControl == null)
        {
            gameControl = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (gameControl != this)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
