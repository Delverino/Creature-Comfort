﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class devSkips : MonoBehaviour
{
    public Dictionary<KeyCode, int> levelDictionary;

    // Start is called before the first frame update
    void Start()
    {
        levelDictionary = new Dictionary<KeyCode, int>();
        levelDictionary.Add(KeyCode.Alpha0, 0);
        levelDictionary.Add(KeyCode.Alpha1, 1);
        levelDictionary.Add(KeyCode.Alpha2, 2);
        levelDictionary.Add(KeyCode.Alpha3, 3);
        levelDictionary.Add(KeyCode.Alpha4, 4);
        levelDictionary.Add(KeyCode.Alpha5, 5);
        levelDictionary.Add(KeyCode.Alpha6, 6);
        levelDictionary.Add(KeyCode.Alpha7, 7);
        levelDictionary.Add(KeyCode.Alpha8, 8);
        levelDictionary.Add(KeyCode.Alpha9, 9);
        levelDictionary.Add(KeyCode.Minus, 10);
        levelDictionary.Add(KeyCode.Equals, 11);
        levelDictionary.Add(KeyCode.E, 12);
        levelDictionary.Add(KeyCode.R, 13);
        levelDictionary.Add(KeyCode.T, 14);
        levelDictionary.Add(KeyCode.Y, 15);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.Z) && levelDictionary.ContainsKey(e.keyCode))
        {
            SceneManager.LoadScene(levelDictionary[e.keyCode]);
        }
    }
}
