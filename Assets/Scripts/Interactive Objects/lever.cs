using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public PlayerMovement mo;
    public PlayerMovement animal;
    public SmartCamera cam;
    public TransformPlayer tp;
    public Animator leverPull;
    public CageOpen cage;
    private bool triggerable;

    void Start()
    {
        animal.enabled = false;
        triggerable = false;
        leverPull.enabled = false;
    }

    void Update()
    {
        // temporarily using E as key
        if (triggerable && Input.GetKeyDown(KeyCode.E))
        {
            // leverPull.enabled = true;
            StartCoroutine(TriggerAnimation());
        }
    }

    IEnumerator TriggerAnimation()
    {
        leverPull.enabled = true;
        yield return new WaitForSeconds(2);
        
        BecomeAnimal();
        cage.cageOpen.enabled = true;
    }

    private void BecomeAnimal()
    {
        mo.enabled = false;
        mo.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        animal.enabled = true;
        cam.Focus(animal.transform);
        Destroy(gameObject);
        tp.on = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerable = false;
        }
    }
}
