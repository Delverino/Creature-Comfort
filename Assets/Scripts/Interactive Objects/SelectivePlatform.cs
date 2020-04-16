using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectivePlatform : MonoBehaviour
{
    public int animal;
    private Collider2D coll;
    private SpriteRenderer sprite;
    private Color init_color;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        init_color = TransformPlayer.Instance.animals[animal].GetComponentInChildren<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (TransformPlayer.Instance.curr_animal == animal)
        {
            coll.enabled = true;
            sprite.color = init_color;
        } else
        {
            coll.enabled = false;
            sprite.color = new Color(init_color.r, init_color.g, init_color.b, 0.5f);
        }
    }
}
