using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imitateColor : MonoBehaviour
{
    public SpriteRenderer target;

    SpriteRenderer sprite;

    Color initColor;
    Color invisible;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        initColor = target.color;
        invisible = initColor;
        invisible.a = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(target.gameObject.activeInHierarchy == false)
        {
            sprite.color = invisible;
        } else
        {
            sprite.color = initColor;
        }
    }
}
