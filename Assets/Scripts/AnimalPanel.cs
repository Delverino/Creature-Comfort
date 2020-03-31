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

    // Functions to update whether or not the panel is showing + if the time is stopped
    void updatePanel() {
        isShowing = !isShowing;
            if (isShowing) {
                Time.timeScale = 0f;
            } else {
                Time.timeScale = 1f;
            }
            
            animalPanel.enabled = isShowing;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            updatePanel();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && isShowing) 
        {
            tp.SetActiveAnimal(0);
            updatePanel();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isShowing) 
        {
            tp.SetActiveAnimal(1);
            updatePanel();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isShowing) 
        {
            tp.SetActiveAnimal(2);
            updatePanel();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && isShowing) 
        {
            tp.SetActiveAnimal(3);
            updatePanel();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && isShowing) 
        {
            tp.SetActiveAnimal(4);
            updatePanel();
        }
    }
}
