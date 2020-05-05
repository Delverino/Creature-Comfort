using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock : MonoBehaviour
{
    public TransformPlayer tp;
    // Create AnimalPanel instance, set canTransform to true on animal
    // collision in if statement
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            tp.on = true;
            tp.animals.Add(collision.gameObject);
            tp.SetActiveAnimal(0);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<PlayerMovement>().enabled = true;
            
        }
    }
}
