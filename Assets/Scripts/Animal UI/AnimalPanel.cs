using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnimalPanel : MonoBehaviour
{
    public Canvas animalPanel;
    public TransformPlayer tp;
    public CanvasGroup panelChildren;
    public bool canTransform;


    List<Button> slots = new List<Button>();

    public Button slot1;
    public Button slot2;
    public Button slot3;
    public Button slot4;
    public Button slot5;

    public Sprite highlightedSlot;
    public Sprite unhighlightedSlot;
    public Sprite emptySlot;

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
        panelChildren = GetComponent<CanvasGroup>();
        canTransform = true;
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
                slots[i].GetComponent<Image>().sprite = unhighlightedSlot;
                //slots[i].GetComponent<Button>().onClick.AddListener(() => updateToAnimal(i-1));
                slots[i].GetComponent<Button>().onClick.AddListener(() => updateToAnimal(i));
            }
            else
            {
                slots[i].GetComponent<Image>().sprite = emptySlot;
                slots[i].transform.GetChild(0).gameObject.SetActive(false);
            }
                
        }
        slots[0].GetComponent<Button>().onClick.AddListener(() => updateToAnimal(0));
        slots[1].GetComponent<Button>().onClick.AddListener(() => updateToAnimal(1));
        slots[2].GetComponent<Button>().onClick.AddListener(() => updateToAnimal(2));
        slots[3].GetComponent<Button>().onClick.AddListener(() => updateToAnimal(3));
        slots[4].GetComponent<Button>().onClick.AddListener(() => updateToAnimal(4));
    }


    // Updates which slot is highlighted based on which animal is selected
    // Also super unoptimized code--there's definitely a better way to do this
    void updatePanel(int highlighted) {
        for (int i = 0; i < 5; i++)
        {
            if (i == highlighted)
            {
                slots[i].GetComponent<Image>().sprite = highlightedSlot;
                slots[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (i < numAnimals)
            {
                slots[i].GetComponent<Image>().sprite = unhighlightedSlot;
                slots[i].transform.GetChild(0).gameObject.SetActive(true);
            } else
            {
                slots[i].GetComponent<Image>().sprite = emptySlot;
            }
        }
        currentlyHighlighted = highlighted;
    }

    private void updateToAnimal(int animal)
    {
        if (animal < numAnimals)
        {
            tp.SetActiveAnimal(animal);
            updatePanel(animal);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Not sure if this is being called too often/if it could slow down
        // the game
        if (numAnimals != tp.animals.Count) {
            numAnimals = tp.animals.Count;
            updatePanel(currentlyHighlighted);
        }

        
        
        if (tp.on && canTransform) 
        {
            var key = Input.inputString;

            if (key == "1") 
            {
                tp.SetActiveAnimal(0);
                slot1.GetComponent<Image>().sprite = highlightedSlot;
                updatePanel(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && 2 <= numAnimals)
            {
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
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                if (canTransform) {
                    Debug.Log("canTransform: True");
                } else
                {
                    Debug.Log("canTransform: False");
                }

            }

            

        }
    }
}
