using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMusicPlayer : MonoBehaviour
{
    //This is a hacky solution and I hate it, but deadlines, man
    void Start()
    {
        Destroy(FindObjectOfType<MusicPlayer>().gameObject);
    }
}
