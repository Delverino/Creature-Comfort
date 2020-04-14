using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickSource : MonoBehaviour
{
    AudioSource clickBox;

    public static clickSource click;

    private void Awake()
    {
        clickBox = GetComponent<AudioSource>();
        click = this;
    }

    void play()
    {
        clickBox.Play();
    }
}
