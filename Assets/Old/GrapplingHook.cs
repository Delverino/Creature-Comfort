using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public Transform rotationPoint;
    public LineRenderer neck;
    public Rigidbody2D body;

    public float speed = 50;

    public Vector2 direction;
    Vector2 actualDirection;

    public LayerMask grappleable;
    public float grappleDistance;

    bool grappled = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //actualDirection = new Vector2(direction.x * Input.GetAxis("Horizontal"), direction.y);

        Debug.DrawLine(transform.position, (Vector3)(direction * grappleDistance) + transform.position);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            grapple();
        }
    }

    void drawNeck()
    {
        neck.gameObject.SetActive(true);
        rotationPoint.gameObject.SetActive(true);
        Vector3 [] startEnd = new Vector3[2];
        startEnd[0] = transform.position;
        startEnd[1] = rotationPoint.position;
        neck.SetPositions(startEnd);
    }

    private void FixedUpdate()
    {
        if (grappled)
        {
            transform.RotateAround(rotationPoint.position, Vector3.forward, speed * Time.fixedDeltaTime);
            drawNeck();
            //body.gravityScale = 0;
            //body.bodyType = RigidbodyType2D.Kinematic;
        } else
        {
            //body.gravityScale = 4;
            //body.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void grapple()
    {
        grappled = true;
        Vector2 hit = Physics2D.Raycast(transform.position, direction, grappleDistance, grappleable).point;
        if(hit == Vector2.zero || Physics2D.OverlapCircle(transform.position, 0.51f, grappleable))
        {
            cutGrapple();
            return;
        } else
        {
            //body.AddForce(Vector2.up* 3);
        }
        rotationPoint.position = hit;
    }

    void cutGrapple() //TODO: call if "cut off" (raycast no longer reaches), if collides with something, or if hold down, or if y dist small
    {
        grappled = false;
        neck.gameObject.SetActive(false);
        rotationPoint.gameObject.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        cutGrapple();
    }
}
