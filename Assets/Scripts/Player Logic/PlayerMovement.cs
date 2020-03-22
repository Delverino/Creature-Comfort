using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Speed the player travels upwards while jumping")]
    public float jump_impulse;
    [Tooltip("Horizontal Speed")]
    public float speed;
    [Tooltip("Rigidbody that controls this object (serialized to save a call to GameObject.Find())")]
    public Rigidbody2D body;

    [Tooltip("Time before impact in which a jump input will still register")]
    public float jump_buffer;

    [Tooltip("Detects ground for the purpose of jumping")]
    public Transform right_foot;
    [Tooltip("Detects ground for the purpose of jumping")]
    public Transform left_foot;


    float jump_expiration;
    [Tooltip("Layer from which the character can jump from")]
    public LayerMask jumpable;

    float coyote_end;
    [Tooltip("Time during which the player can still jump after leaving the ground (named after Wil E Coyote)")]
    public float coyote_time = 0.1f;

    float jump_end;
    [Tooltip("Time the player moves upwards while jumping")]
    public float jump_time;
    [Tooltip("Time the player floats at the top of the jump arc")]
    public float hang_time = 0.1f;


    [Tooltip("The main camera which follows the player")]
    public SmartCamera Cam;


    [Tooltip("An audiosource with the clip for jumping loaded")]
    public AudioSource jump_sound;

    // Update is called once per frame
    void Update()
    {
        //Checks if player is touching ground (Collisions are apporximated by a small circle around its "feet")
        if (Physics2D.OverlapCircle(left_foot.position, 0.01f, jumpable) || Physics2D.OverlapCircle(right_foot.position, 0.01f, jumpable))
        {
            beginCoyote();
        }
        //Registers a jump input if either the up arrow or w key is pressed
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) //Won't work with controller input TODO
        {
            jumpInput(); 
        }
    }

    private void FixedUpdate()
    {
        //Sets the horizontal velocity to the input times the speed
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);



        //Jump logic!
        if ( (jumpIsBuffered() /*|| Input.GetAxis("Vertical") == 1*/) && isGrounded()) //Begin Jump when it hits the ground if the player is holding jump or had a jump buffered
        {
            jump_sound.Play();
            body.velocity = new Vector2(body.velocity.x, jump_impulse);
            coyote_end = 0;
            jump_end = jump_time + Time.realtimeSinceStartup;

        } else if(Input.GetAxis("Vertical") > 0 && Time.realtimeSinceStartup < jump_end) //Keep jumping if they hold the key
        {

            body.velocity = new Vector2(body.velocity.x, jump_impulse);

        } else if(Input.GetAxis("Vertical") > 0 && Time.realtimeSinceStartup < jump_end + hang_time) //Hang in the air during hang time
        {

            body.velocity = new Vector2(body.velocity.x, 0);

        } else //Otherwise make sure no inputs are being counted and cut the velocitys
        {

            body.velocity = new Vector2(body.velocity.x, Mathf.Min(body.velocity.y, 0));
            jump_end = 0;

        }
    }

    //Begins Coyote time
    void beginCoyote()
    {
        coyote_end = coyote_time + Time.realtimeSinceStartup;
    }

    //Checks if still within Coyote time
    bool isGrounded()
    {
        return Time.realtimeSinceStartup < coyote_end;
    }

    //Begins jump buffer
    void jumpInput()
    {
        jump_expiration = jump_buffer + Time.realtimeSinceStartup;
    }

    //Checks if a jump is buffered
    bool jumpIsBuffered()
    {
        return Time.realtimeSinceStartup < jump_expiration;
    }

    private void OnTriggerEnter2D(Collider2D collision) //TODO change to ontriggerstay2d, and implement a focus stack on camera
    {
        if (collision.gameObject.CompareTag("CameraFocus"))
        {
            Cam.Focus(collision.gameObject.transform, collision.transform.localScale.y);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraFocus"))
        {
            Cam.RemoveView(collision.gameObject.transform);
            Debug.Log(gameObject);
        }
    }
}
