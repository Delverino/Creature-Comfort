using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
