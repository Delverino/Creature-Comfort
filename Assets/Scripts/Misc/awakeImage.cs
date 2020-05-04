using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class awakeImage : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Image>().enabled = true;
    }
}
