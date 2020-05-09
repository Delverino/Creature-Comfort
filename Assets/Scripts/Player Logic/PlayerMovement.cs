using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject dust;

    public bool jumpOverride;

    [Tooltip("Speed the player travels upwards while jumping")]
    public float jump_impulse;
    [Tooltip("Horizontal Speed")]
    public float speed;
    [Tooltip("Rigidbody that controls this object (serialized to save a call to GameObject.Find())")]
    public Rigidbody2D body;

    //[Tooltip("Time before impact in which a jump input will still register")]
    //public float jump_buffer;
    bool jump_is_buffered;

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

    //float jump_end;
    [Tooltip("Time the player moves upwards while jumping")]
    public float jump_time;
    [Tooltip("Time the player floats at the top of the jump arc")]
    public float hang_time = 0.1f;


    [Tooltip("The main camera which follows the player")]
    public SmartCamera Cam;


    [Tooltip("An audiosource with the clip for jumping loaded")]
    public AudioSource jump_sound;

    //public TransformPlayer manager;


    // Accounting for Mouse
    private bool isMouse;
    public Transform top;
    public Transform left;
    public Transform right;
    public AnimalPanel animalPanel;

    float base_gravity;
    private void Awake()
    {
        base_gravity = body.gravityScale;
    }

    private void Start()
    {
        if (top == null || left == null || right == null)
        {
            isMouse = false;
            top = new GameObject().transform;
            left = new GameObject().transform;
            right = new GameObject().transform;
        }
        else
        {
            isMouse = true;
        }
    }

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

        if (Physics2D.OverlapCircle(left_foot.position, 0.01f, jumpable) || Physics2D.OverlapCircle(right_foot.position, 0.01f, jumpable))
        {
            if (isMouse)
            {
                if ((Physics2D.OverlapCircle(top.position, 0.01f, jumpable)) || (Physics2D.OverlapCircle(left.position, 0.01f, jumpable)) || (Physics2D.OverlapCircle(left.position, 0.01f, jumpable)))
                {
                    Debug.Log("In moss");
                    animalPanel.canTransform = false;
                } else
                {
                    Debug.Log("not in moss");
                    animalPanel.canTransform = true;
                }
                    
            } 
            
        }


        //if (Physics2D.OverlapCircle(top.position, 0.01f, jumpable) && isMouse)
        //{
        //    Debug.Log("Touching top");
        //}
        //if (Physics2D.OverlapCircle(left.position, 0.01f, jumpable) && isMouse)
        //{
        //    Debug.Log("Touching left");
        //}
        //if (Physics2D.OverlapCircle(right.position, 0.01f, jumpable) && isMouse)
        //{
        //    Debug.Log("Touching right");
        //}
    }

    void jump()
    {
            jump_sound.Play();
            OnDust();
            body.velocity = new Vector2(body.velocity.x, jump_impulse);
            coyote_end = 0;
            TransformPlayer.Instance.jump_begin = Time.time;
            jump_is_buffered = false;
            TransformPlayer.Instance.state = "jumping";
    }

    private void FixedUpdate()
    {
        //Sets the horizontal velocity to the input times the speed
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        switch (TransformPlayer.Instance.state)
        {
            case "grounded": // in coyote time
                //body.gravityScale = base_gravity;
                if (jump_is_buffered)
                {
                    jump();
                }
                break;

            case "jumping":  // going upward
                body.velocity = new Vector2(body.velocity.x, jump_impulse);
                /*if (jumpOverride)
                {
                    jump();
                }*/
                //body.gravityScale = base_gravity;
                jump_is_buffered = false;
                if (Input.GetAxis("Vertical") <= 0)
                {
                    TransformPlayer.Instance.state = "falling";
                } else if (Time.time > TransformPlayer.Instance.jump_begin + jump_time)
                {
                    TransformPlayer.Instance.state = "floating";
                }
                break;

            case "floating": // 0 y velocity (potentially gravity off)
                //body.gravityScale = 0;
                body.velocity = new Vector2(body.velocity.x, 0);
                if (Input.GetAxis("Vertical") != 1 || Time.time > TransformPlayer.Instance.jump_begin + jump_time + hang_time)
                {
                    TransformPlayer.Instance.state = "falling";
                }
                break;

            case "falling":  // set in freefall
                             //body.gravityScale = base_gravity;
                /*if (Input.GetAxis("Vertical") == 1 && Time.time < TransformPlayer.Instance.jump_begin + jump_time + hang_time)
                {
                    TransformPlayer.Instance.state = "floating";
                }*/
                body.velocity = new Vector2(body.velocity.x, Mathf.Min(body.velocity.y, 0));
                //jump_end = 0;
                break;
        }
    }
    void OnDust()
    {
        Instantiate(dust, transform);
        //dust.GetComponent<ParticleSystem>().Play();
    }

    //Begins Coyote time
    void beginCoyote()
    {
        TransformPlayer.Instance.state = "grounded";
        coyote_end = coyote_time + Time.time;
    }

    //Checks if still within Coyote time
    bool isGrounded()
    {
        return Time.time < coyote_end;
    }

    //Begins jump buffer
    void jumpInput()
    {
        if (body.velocity.y <= 0 || isGrounded())
        {
            jump_is_buffered = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.gameObject.CompareTag("CameraFocus"))
        {
            Cam.Focus(other.gameObject.transform, other.transform.localScale.y);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.sqrMagnitude > 400)
        {
            OnDust();
        }
    }
}
