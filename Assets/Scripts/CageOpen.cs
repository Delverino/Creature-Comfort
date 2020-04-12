using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageOpen : MonoBehaviour
{
    public Animator cageOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        cageOpen.enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cageOpen.enabled) 
        {
            StartCoroutine(OpenCage());
        }
    }

    IEnumerator OpenCage()
    {
        yield return new WaitForSeconds(1);
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}
