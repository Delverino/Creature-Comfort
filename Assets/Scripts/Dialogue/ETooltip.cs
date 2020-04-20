using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETooltip : MonoBehaviour
{
    public Canvas tooltip;

    void Start()
    {
        Debug.Log("starting");
        tooltip.GetComponent<Canvas>().enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Animal")
        {
            Debug.Log("colliding");
            tooltip.GetComponent<Canvas>().enabled = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Animal")
        {
            Debug.Log("leaving collider");
            tooltip.GetComponent<Canvas>().enabled = false;
        } 
    }

}
