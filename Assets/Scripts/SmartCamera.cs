using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartCamera : MonoBehaviour
{
    public Transform main_target;
    public float response;

    Transform curr_target;
    float target_size;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        curr_target = main_target;
        target_size = cam.orthographicSize;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, curr_target.position, response);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, target_size, response);
    }

    public void focus(Transform new_target, float height)
    {
        curr_target = new_target;
        target_size = height / 2;
    }
}
