using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public float scrollSpeed;

    public Camera cam;
    Transform camTransform;

    SpriteRenderer sprite;

    Vector3 prevCamPos;
    Vector3 currCamPos;
    float xDiff;

    float spriteWidth;
    float spriteHeight;
    float camWidth;
    float camHeight;

    public List<GameObject> filler;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = cam.gameObject.transform;
        sprite = filler[0].GetComponent<SpriteRenderer>();

        prevCamPos = camTransform.position;
        currCamPos = prevCamPos;

        spriteWidth = sprite.bounds.size.x;
        spriteHeight = sprite.bounds.size.y;

        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    private void Update()
    {
        inverseScrollHorizontal();

        Debug.Log("Inside left: " + insideLeft(filler[0]));
        Debug.Log("Inside right: " + insideRight(filler[0]));
        /*        if (offLeft())
                {
                    moveRight();
                } else if (offRight())
                {
                    moveLeft();
                }*/
    }

    #region old
    
        void inverseScrollHorizontal()
        {
            prevCamPos = currCamPos;
            currCamPos = camTransform.position;

            xDiff = currCamPos.x - prevCamPos.x;

            transform.localPosition -= Vector3.right * xDiff * scrollSpeed;
        }
    
        bool insideLeft(GameObject g)
        {
            float leftSprite = g.transform.position.x - (spriteWidth / 2);
            float leftCam = camTransform.position.x - (camWidth / 2);
            return leftSprite > leftCam;
        }

        bool insideRight(GameObject g)
      {
            float rightSprite = g.transform.position.x + (spriteWidth / 2);
            float rightCam = camTransform.position.x + (camWidth / 2);
            return rightSprite < rightCam;
        }
    /*
        void moveRight()
        {
            float newX = camTransform.position.x + ((camWidth + spriteWidth) / 2);
            Vector3 tempPos = transform.position;
            tempPos.x = newX;
            transform.position = tempPos;
        }

        void moveLeft()
        {
            float newX = camTransform.position.x - ((camWidth + spriteWidth) / 2);
            Vector3 tempPos = transform.position;
            tempPos.x = newX;
            transform.position = tempPos;
        }*/
    #endregion
}
