using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartCamera : MonoBehaviour
{
    public class view
    {
        public Transform transform;
        public float size;
    }


    public Transform main_target;
    public float response;

    Transform curr_target;
    float target_size;

    public Camera cam;

    public List<view> views;

    private float zoom;

    float wait_time = 0.1f;
    float stop_waiting = 0;

    public Transform bottomLeftBound;
    public Transform topRightBound;

    float camHeight;
    float camWidth;

    float minX;
    float maxX;
    float minY;
    float maxY;

    public float cinematicTime;

    Vector3 newPos;

    // Start is called before the first frame update
    void Awake()
    {
        if(bottomLeftBound.localPosition == topRightBound.localPosition)
        {
            Debug.LogError("Please set the bounds of the camera: " + gameObject);
        }

        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        minX = bottomLeftBound.position.x;
        minY = bottomLeftBound.position.y;

        maxX = topRightBound.position.x;
        maxY = topRightBound.position.y;

        views = new List<view>();
        view main_view = new view();
        main_view.transform = main_target;
        main_view.size = cam.orthographicSize;
        views.Add(main_view);
    }

    public void TempFocus(GameObject focalPoint){
        StartCoroutine(cinematic(focalPoint));
        //cam.orthographicSize = 100;
        //Debug.Log("zooming out");
    }

    IEnumerator cinematic(GameObject focalPoint)
    {
        view new_view = new view();
        new_view.transform = focalPoint.transform;
        new_view.size = focalPoint.transform.localScale.y / 2;
        views.Add(new_view);
        yield return new WaitForSeconds(cinematicTime);
        RemoveView(focalPoint.transform);
    }

    private void FixedUpdate()
    {
        curr_target = views[views.Count - 1].transform;
        if (Time.realtimeSinceStartup > stop_waiting)
        {
            transform.position = Vector3.Lerp(transform.position, views[views.Count - 1].transform.position, response);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, views[views.Count - 1].size, response);
            
            camHeight = 2f * cam.orthographicSize;
            camWidth = camHeight * cam.aspect;

            if(maxY - minY > camHeight && maxX - minX > camWidth)
            {
                newPos.y = Mathf.Clamp(transform.position.y, minY + (camHeight / 2), maxY - (camHeight / 2));
                newPos.x = Mathf.Clamp(transform.position.x, minX + (camWidth / 2), maxX - (camWidth / 2));
                newPos.z = -10;
                transform.position = newPos;
            }

        }
    }

    public void Focus(Transform new_target, float height)
    {
        view new_view = new view();
        new_view.transform = new_target;
        new_view.size = height / 2;
        views.Add(new_view);
        //Debug.Log(views.Count);
        stop_waiting = wait_time + Time.realtimeSinceStartup;
    }

    public void Focus(Transform new_target)
    {
        view new_view = new view();
        new_view.transform = new_target;
        new_view.size = views[0].size;
        views[0] = new_view;
        //Debug.Log("new character focus");
        stop_waiting = wait_time + Time.realtimeSinceStartup;
    }

    public void RemoveView(Transform t)
    {
        //Debug.Log("removing " + t);
        for (int i = 0; i < views.Count; i++)
        {
            if(views[i].transform == t)
            {
                views.RemoveAt(i);
            }
        }
        stop_waiting = wait_time + Time.realtimeSinceStartup;
    }
}
