using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource soundToPlay;
    // Start is called before the first frame update
    void Start()
    {
        soundToPlay.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
