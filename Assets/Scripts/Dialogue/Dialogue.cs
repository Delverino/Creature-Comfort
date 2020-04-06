using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{   
        // NOTE: size of names and sentences MUST be the same!!!
        // allows for multiple characters within dialogue
        // TODO: this is kinda hackey... find a more modular way?

        // public string[] names;
        [TextArea(3, 10)]
        public Canvas[] canvases;
        public string[] sentences;
}
