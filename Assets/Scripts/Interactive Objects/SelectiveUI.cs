using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectiveUI : MonoBehaviour
{
    public int animal;
    private Image tooltip;
    private Color init_color;

    // Start is called before the first frame update
    void Start()
    {
        tooltip = GetComponent<Image>();
        init_color = TransformPlayer.Instance.animals[animal].GetComponentInChildren<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (TransformPlayer.Instance.curr_animal == animal)
        {
            tooltip.color = init_color;
        } else
        {
            tooltip.color = new Color(init_color.r, init_color.g, init_color.b, 0.5f);
        }
    }
}
