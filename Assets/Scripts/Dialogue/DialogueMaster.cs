using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMaster : MonoBehaviour
{
    public Canvas[] dialogueCanvases;
    
    // Start is called before the first frame update
    void Start()
    {
        shutBubbles();
    }

    public void shutBubbles()
    {
        foreach (Canvas canvas in dialogueCanvases)
        {
            canvas.GetComponent<Canvas>().enabled = false;
        }
    }
}
