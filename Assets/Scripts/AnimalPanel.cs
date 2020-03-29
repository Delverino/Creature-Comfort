using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalPanel : MonoBehaviour
{
    public Canvas animalPanel;
    public TransformPlayer tp;

    
    private bool isShowing = false;

    // Start is called before the first frame update
    void Start()
    {
        animalPanel = GetComponent<Canvas> ();
        animalPanel.enabled = isShowing;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isShowing = !isShowing;
            
            if (isShowing) {
                Time.timeScale = 0f;
            } else {
                Time.timeScale = 1f;
            }
            
            animalPanel.enabled = isShowing;
        }
    }
}
