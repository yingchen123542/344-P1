using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueNode
{
    //VARIABLES
    // public string name;
    // public bool isImageFlipped;
    [TextArea(3, 10)]
    public string sentence;

    //GETTERS
    // public string GetName()
    // {
    //     return name;
    // }


    public string GetSentence()
    {
        return sentence;
    }

    // public bool GetIsImageFlipped()
    // {
    //     return isImageFlipped;
    // }
}
