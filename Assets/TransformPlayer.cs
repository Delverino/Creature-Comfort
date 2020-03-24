﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayer : MonoBehaviour
{
    public List<GameObject> animals; // will be updated externally as animals
                                     // are unlocked
    private int curr_animal;
    public SmartCamera cam;
    public bool on;

    // Start is called before the first frame update
    void Start()
    {
        SetActiveAnimal(animals[0].transform.position, 0);
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetActiveAnimal(animals[curr_animal].transform.position, (curr_animal + 1) % animals.Count);
        }
    }

    // returns previously active animal and sets new one
    public void SetActiveAnimal(Vector3 position, int new_animal)
    {
        if (on)
        {
            animals[new_animal].SetActive(true);
            animals[new_animal].transform.position = position;
            cam.Focus(animals[new_animal].transform);

            for (int i = 0; i < animals.Count; i++)
            {
                if (i != new_animal)
                {
                    animals[i].SetActive(false);
                }
            }

            curr_animal = new_animal;
        }
    }
}
