using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnCollide : MonoBehaviour
{
    public float BreakSpeed = 40;
    public Rigidbody2D body;


    public AudioSource a;
    //float speed_buffer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Mathf.Abs(body.velocity.y) > BreakSpeed)
        {
            speed_buffer = Time.realtimeSinceStartup + 0.1f;
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            if(collision.relativeVelocity.sqrMagnitude > BreakSpeed * BreakSpeed)
            {
                Destroy(collision.gameObject);
                a.Play();
            }
        }
    }
}
