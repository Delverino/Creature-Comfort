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

    [Tooltip("Default height of the camera")]
    public float base_height;

    public List<view> views;

    private float zoom;

    float wait_time = 0.1f;
    float stop_waiting = 0;

    // Start is called before the first frame update
    void Awake()
    {
        views = new List<view>();
        view main_view = new view();
        main_view.transform = main_target;
        main_view.size = cam.orthographicSize;
        views.Add(main_view);
    }

    public void ZoomOut(){
    	Debug.Log("zooming out");
    }

    private void FixedUpdate()
    {
        if (Time.realtimeSinceStartup > stop_waiting)
        {
            transform.position = Vector3.Lerp(transform.position, views[views.Count - 1].transform.position, response);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, views[views.Count - 1].size, response);
        }
    }

    public void Focus(Transform new_target, float height)
    {
        view new_view = new view();
        new_view.transform = new_target;
        new_view.size = height / 2;
        views.Add(new_view);
        Debug.Log(views.Count);
        stop_waiting = wait_time + Time.realtimeSinceStartup;
    }

    public void Focus(Transform new_target)
    {
        view new_view = new view();
        new_view.transform = new_target;
        new_view.size = views[0].size;
        views[0] = new_view;
        Debug.Log("new character focus");
        stop_waiting = wait_time + Time.realtimeSinceStartup;
    }

    public void RemoveView(Transform t)
    {
        Debug.Log("removing " + t);
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
