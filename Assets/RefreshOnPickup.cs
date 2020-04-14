﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshOnPickup : MonoBehaviour
{
    public TransformPlayer tp;
    public string refresh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(refresh))
        {
            tp.state = "grounded";
            Destroy(collision.gameObject);
        }
    }
}
