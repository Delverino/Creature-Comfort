using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thud_on_collision : MonoBehaviour
{
    public AudioSource thud;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        thud.Play();
    }
}
