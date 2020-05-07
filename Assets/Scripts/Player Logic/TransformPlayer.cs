using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayer : MonoBehaviour
{
    public static TransformPlayer Instance;
    public AnimalPanel animalPanel;

    public List<GameObject> animals; // will be updated externally as animals
                                     // are unlocked
    public List<AudioClip> sounds;
    public AudioSource speaker;


    public int curr_animal;
    public SmartCamera cam;
    public bool on;

    public string state; //possibly should be enumerated, this should store "grounded", "jumping", "floating", "falling"
    public float jump_begin; //store when the player last jumped

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        curr_animal = 0;
        SetActiveAnimal(0);
        state = "falling";
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     SetActiveAnimal((curr_animal + 1) % animals.Count);
        // }
    }

    // returns previously active animal and sets new one
    public void SetActiveAnimal(int new_animal)
    {
        // If not in the middle of an animal puzzle
        if (on)
        {
            if (sounds.Count <= new_animal)
            {
                Debug.Log("Error: Add more sounds to the list on " + gameObject);
            } else if(Time.timeSinceLevelLoad > 0.1f)
            {
                speaker.clip = sounds[new_animal];
                speaker.Play();
            }
            animals[new_animal].SetActive(true);
            animals[new_animal].transform.position = animals[curr_animal].transform.position;

            animals[new_animal].GetComponent<Rigidbody2D>().velocity = animals[curr_animal].GetComponent<Rigidbody2D>().velocity;
            cam.Focus(animals[new_animal].transform);

            for (int i = 0; i < animals.Count; i++)
            {
                if (i != new_animal)
                {
                    animals[i].SetActive(false);
                }
            }
            curr_animal = new_animal;

            
        } else
        {
            // Set animal panel to be false: we are unlocking a new animal
            animalPanel.canTransform = false;
        }
    }
}
