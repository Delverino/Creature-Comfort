using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refreshable : MonoBehaviour
{
    public float refreshTime;

    Collider2D coll;
    SpriteRenderer sprite;
    Color initColor;
    Color invisible;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        initColor = sprite.color;
        invisible = initColor;
        invisible.a = 0;
    }

    public void eat()
    {
        coll.enabled = false;
        sprite.color = invisible;
        StartCoroutine(growBack());
    }

    IEnumerator growBack()
    {
        yield return new WaitForSeconds(refreshTime);
        coll.enabled = true;
        sprite.color = initColor;
    }

}
