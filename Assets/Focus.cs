using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{
    public float size;

    private void Awake()
    {
        size = transform.localScale.y / 2;
    }
}
