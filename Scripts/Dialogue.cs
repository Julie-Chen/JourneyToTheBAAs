using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Dialogue
{ 
    [TextArea(1,50)] //When you give an object the DialogueTrigger Script, you can input the size of the dialogue and include the order of the appearance of the names in the dialogue box
    // Hence the TextArea thing (bruh i can't believe i spent a good 10 hours on this dialogue box)
    public string[] names;

    [TextArea(3, 50)]
    public string[] sentences;
}
