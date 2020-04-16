using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalPanel : MonoBehaviour
{
    public Canvas animalPanel;
    public TransformPlayer tp;

    public Button slot1;
    public Button slot2;
    public Button slot3;
    public Button slot4;
    public Button slot5;

    public Sprite highlightedSlot;
    public Sprite unhighlightedSlot;

    private int numAnimalsUnlocked;

    // Initially sets highlighted animalPanel to Mo--this can be
    // changed/done better
    // especially if a level starts with an animal that is not Mo. 
    void Start()
    {
        animalPanel = GetComponent<Canvas> ();
        updatePanel(1);
        numAnimalsUnlocked = tp.animals.Count;

    }

    // Updates which slot is highlighted based on which animal is selected
    // Also super unoptimized code--there's definitely a better way to do this
    void updatePanel(int numAnimal) {
        

        switch (numAnimal)
        {
            case 1:
                
                slot1.GetComponent<Image>().sprite = highlightedSlot;
                slot2.GetComponent<Image>().sprite = unhighlightedSlot;
                slot3.GetComponent<Image>().sprite = unhighlightedSlot;
                slot4.GetComponent<Image>().sprite = unhighlightedSlot;
                slot5.GetComponent<Image>().sprite = unhighlightedSlot;
                break;
            case 2:
                slot1.GetComponent<Image>().sprite = unhighlightedSlot;
                slot2.GetComponent<Image>().sprite = highlightedSlot;
                slot3.GetComponent<Image>().sprite = unhighlightedSlot;
                slot4.GetComponent<Image>().sprite = unhighlightedSlot;
                slot5.GetComponent<Image>().sprite = unhighlightedSlot;
                break;
            case 3:
                slot1.GetComponent<Image>().sprite = unhighlightedSlot;
                slot2.GetComponent<Image>().sprite = unhighlightedSlot;
                slot3.GetComponent<Image>().sprite = highlightedSlot;
                slot4.GetComponent<Image>().sprite = unhighlightedSlot;
                slot5.GetComponent<Image>().sprite = unhighlightedSlot;
                break;
            case 4:
                slot1.GetComponent<Image>().sprite = unhighlightedSlot;
                slot2.GetComponent<Image>().sprite = unhighlightedSlot;
                slot3.GetComponent<Image>().sprite = unhighlightedSlot;
                slot4.GetComponent<Image>().sprite = highlightedSlot;
                slot5.GetComponent<Image>().sprite = unhighlightedSlot;
                break;
            case 5:
                slot1.GetComponent<Image>().sprite = unhighlightedSlot;
                slot2.GetComponent<Image>().sprite = unhighlightedSlot;
                slot3.GetComponent<Image>().sprite = unhighlightedSlot;
                slot4.GetComponent<Image>().sprite = unhighlightedSlot;
                slot5.GetComponent<Image>().sprite = highlightedSlot;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Not sure if this is being called too often/if it could slow down
        // the game
        numAnimalsUnlocked = tp.animals.Count;

        if (tp.on) 
        {
        var key = Input.inputString;

        if (key == "1") 
        {
            tp.SetActiveAnimal(0);
            slot1.GetComponent<Image>().sprite = highlightedSlot;
            updatePanel(1);
            }
        if (Input.GetKeyDown(KeyCode.Alpha2) && 2 <= numAnimalsUnlocked) 
        {
            tp.SetActiveAnimal(1);
            updatePanel(2);
            }
        if (Input.GetKeyDown(KeyCode.Alpha3) && 3 <= numAnimalsUnlocked) 
        {
            tp.SetActiveAnimal(2);
            updatePanel(3);
            }
        if (Input.GetKeyDown(KeyCode.Alpha4) && 4 <= numAnimalsUnlocked) 
        {
            tp.SetActiveAnimal(3);
            updatePanel(4);
            }
        if (Input.GetKeyDown(KeyCode.Alpha5) && 5 <= numAnimalsUnlocked) 
        {
            tp.SetActiveAnimal(4);
            updatePanel(5);
        }
    }
    }
}
