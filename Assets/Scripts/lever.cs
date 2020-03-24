using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public PlayerMovement mo;
    public PlayerMovement animal;
    public SmartCamera cam;
    public TransformPlayer tp;

    void Start()
    {
        animal.enabled = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mo.enabled = false;
            mo.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            animal.enabled = true;
            cam.Focus(animal.transform);
            Destroy(gameObject);
            tp.on = false;
        }


    }
}
