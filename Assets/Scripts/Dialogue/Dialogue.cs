using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{   
        // NOTE: size of canvases and sentences MUST be the same!!!
        // allows for multiple characters within dialogue
        
        public Canvas[] canvases;
        [TextArea(3, 10)]
        public string[] sentences;
}
