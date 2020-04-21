using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inverseScrollHorizontal : MonoBehaviour
{
    public float scrollSpeed;

    public Camera cam;
    Transform camTransform;

    SpriteRenderer sprite;

    Vector3 prevCamPos;
    Vector3 currCamPos;
    float xDiff;

    // Start is called before the first frame update
    void Start()
    {
        

        camTransform = cam.gameObject.transform;
        sprite = GetComponent<SpriteRenderer>();

        prevCamPos = camTransform.position;
        currCamPos = prevCamPos;

        //RectTransform rt = (RectTransform)transform;
        Debug.Log("image width: " + sprite.bounds.size.x/*rt.rect.width*/);
        Debug.Log("image height: " + sprite.bounds.size.y);

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Debug.Log("camera width: " + width);
        Debug.Log("camera height: " + height);
    }

    private void Update()
    {
        prevCamPos = currCamPos;
        currCamPos = camTransform.position;

        xDiff = currCamPos.x - prevCamPos.x;

        transform.localPosition -= Vector3.right * xDiff * scrollSpeed;

        
    }
}
