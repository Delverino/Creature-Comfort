using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalPanel : MonoBehaviour
{
    public Canvas animalPanel;
    public TransformPlayer tp;

    List<Button> slots = new List<Button>();

    public Button slot1;
    public Button slot2;
    public Button slot3;
    public Button slot4;
    public Button slot5;

    public Sprite highlightedSlot;
    public Sprite unhighlightedSlot;

    // Invariant: will never be higher than numAnimals
    private int currentlyHighlighted;

    // Currently set automatically to be the number of animals in the
    // Transformation manager
    public int numAnimals;
    

    // Initially sets highlighted animalPanel to Mo--this might be better
    // done by a public variable 
    void Start()
    {
        animalPanel = GetComponent<Canvas> ();
        
        currentlyHighlighted = 0;

        numAnimals = tp.animals.Count;

        // Better way to do this: get buttons by getting children
        // of parent object
        slots.Add(slot1);
        slots.Add(slot2);
        slots.Add(slot3);
        slots.Add(slot4);
        slots.Add(slot5);

        // Setting up slot images--set Mo's slot to be highlighted and every other
        // slot not 
        slots[0].GetComponent<Image>().sprite = highlightedSlot;
        for (int i = 1; i < 5; i++)
        {
            if (i < numAnimals)
            {
                Debug.Log("Setting Slot " + i + " to be unhighlighted");
                slots[i].GetComponent<Image>().sprite = unhighlightedSlot;
            }
            else
            {
                Debug.Log("Setting Slot " + i + " to be inactive");
                slots[i].GetComponent<Image>().sprite = null;
            }
        }
    }

    // Updates which slot is highlighted based on which animal is selected
    // Also super unoptimized code--there's definitely a better way to do this
    void updatePanel(int highlighted) {
        for (int i = 0; i < 5; i++)
        {
            if (i == highlighted)
            {
                slots[i].GetComponent<Image>().sprite = highlightedSlot;
            } else if (i < numAnimals)
            {
                slots[i].GetComponent<Image>().sprite = unhighlightedSlot;
            } else
            {
                slots[i].GetComponent<Image>().sprite = null;
            }
        }
        currentlyHighlighted = highlighted;
        //switch (highlighted)
        //{
        //    case 1:
        //        slot1.GetComponent<Image>().sprite = highlightedSlot;
        //        slot2.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot3.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot4.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot5.GetComponent<Image>().sprite = unhighlightedSlot;
        //        break;
        //    case 2:
        //        slot1.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot2.GetComponent<Image>().sprite = highlightedSlot;
        //        slot3.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot4.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot5.GetComponent<Image>().sprite = unhighlightedSlot;
        //        break;
        //    case 3:
        //        slot1.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot2.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot3.GetComponent<Image>().sprite = highlightedSlot;
        //        slot4.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot5.GetComponent<Image>().sprite = unhighlightedSlot;
        //        break;
        //    case 4:
        //        slot1.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot2.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot3.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot4.GetComponent<Image>().sprite = highlightedSlot;
        //        slot5.GetComponent<Image>().sprite = unhighlightedSlot;
        //        break;
        //    case 5:
        //        slot1.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot2.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot3.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot4.GetComponent<Image>().sprite = unhighlightedSlot;
        //        slot5.GetComponent<Image>().sprite = highlightedSlot;
        //        break;
        //    default:
        //        break;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // Not sure if this is being called too often/if it could slow down
        // the game
        numAnimals = tp.animals.Count;
        updatePanel(currentlyHighlighted);
        Debug.Log(tp.on);
        if (tp.on) 
        {
        var key = Input.inputString;

        if (key == "1") 
        {
            Debug.Log("Setting Mo");
            tp.SetActiveAnimal(0);
            slot1.GetComponent<Image>().sprite = highlightedSlot;
            updatePanel(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && 2 <= numAnimals)
        {
            Debug.Log("Setting Kangaroo");
            tp.SetActiveAnimal(1);
            updatePanel(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && 3 <= numAnimals) 
        {
            tp.SetActiveAnimal(2);
            updatePanel(2);
            }
        if (Input.GetKeyDown(KeyCode.Alpha4) && 4 <= numAnimals) 
        {
            tp.SetActiveAnimal(3);
            updatePanel(3);
            }
        if (Input.GetKeyDown(KeyCode.Alpha5) && 5 <= numAnimals) 
        {
            tp.SetActiveAnimal(4);
            updatePanel(4);
        }
    }
    }
}
