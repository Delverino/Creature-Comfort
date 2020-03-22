﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayer : MonoBehaviour
{
    public List<GameObject> animals;
    private int curr_animal;
    public SmartCamera cam;

    // Start is called before the first frame update
    void Start()
    {
        SetActiveAnimal(animals[0].transform.position, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            SetActiveAnimal(animals[curr_animal].transform.position, (curr_animal + 1) % animals.Count);
        }
    }

    // returns previously active animal and sets new one
    void SetActiveAnimal(Vector3 position, int new_animal)
    {
        for ( int i = 0; i < animals.Count; i++ )
        {
            if ( i == new_animal )
            {
                animals[i].SetActive(true);
                animals[i].transform.position = position;
                cam.Focus(animals[i].transform);
            }
            else
            {
                animals[i].SetActive(false);
            }
        }

        curr_animal = new_animal;

    }
}
