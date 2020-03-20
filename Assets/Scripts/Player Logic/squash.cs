using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squash : MonoBehaviour
{
    public Rigidbody2D body;

    public Vector3 init_transform;
    public Vector3 squish;
    public Vector3 stretch;

    public float y_threshold;
    public float change_threshold;

    //all in reference to just the y motion
    float velocity_diff = 0;
    float last_velocity = 0;
    float curr_velocity;

    public float elasticity;

    public Vector3 target;

    private void FixedUpdate()
    {
        curr_velocity = body.velocity.y;
        velocity_diff = curr_velocity - last_velocity;
        last_velocity = curr_velocity;

        if(Mathf.Abs(curr_velocity) > y_threshold)
        {
            target = stretch;
        } else if (velocity_diff > change_threshold)
        {
            transform.localScale = squish;
        }
        else
        {
           target = init_transform;
        }

        transform.localScale = Vector3.Lerp(transform.localScale, target, elasticity);
    }
}
