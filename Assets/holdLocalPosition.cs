using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdLocalPosition : MonoBehaviour
{
    public float response;

    public Transform tether;

    Vector3 homePos;

    // Start is called before the first frame update
    void Start()
    {
        homePos = transform.position - tether.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.position, tether.position + homePos, response);
    }
}
