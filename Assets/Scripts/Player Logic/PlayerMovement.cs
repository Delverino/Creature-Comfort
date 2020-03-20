using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jump_impulse;
    public float speed;
    public Rigidbody2D body;

    public float jump_buffer;

    public Transform right_foot;
    public Transform left_foot;

    float jump_expiration;
    public LayerMask jumpable;

    float coyote_end;
    public float coyote_time = 0.1f;

    float jump_end;
    public float jump_time;
    public float hang_time = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(left_foot.position, 0.01f, jumpable) || Physics2D.OverlapCircle(right_foot.position, 0.01f, jumpable))
        {
            beginCoyote();
        }
        if (Input.GetAxis("Vertical") > 0 && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            jumpInput();
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);


        if ( (jumpIsBuffered() || Input.GetAxis("Vertical") == 1) && isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jump_impulse);
            coyote_end = 0;
            jump_end = jump_time + Time.realtimeSinceStartup;
        } else if(Input.GetAxis("Vertical") > 0 && Time.realtimeSinceStartup < jump_end)
        {
            body.velocity = new Vector2(body.velocity.x, jump_impulse);
        } else if(Input.GetAxis("Vertical") > 0 && Time.realtimeSinceStartup < jump_end + hang_time)
        {
            body.velocity = new Vector2(body.velocity.x, 0);
        } else
        {
            body.velocity = new Vector2(body.velocity.x, Mathf.Min(body.velocity.y, 0));

            jump_end = 0;
            jump_expiration = 0;
        }
    }

    void beginCoyote()
    {
        coyote_end = coyote_time + Time.realtimeSinceStartup;
    }

    bool isGrounded()
    {
        return Time.realtimeSinceStartup < coyote_end;
    }

    void jumpInput()
    {
        jump_expiration = jump_buffer + Time.realtimeSinceStartup;
    }

    bool jumpIsBuffered()
    {
        return Time.realtimeSinceStartup < jump_expiration;
    }
}
