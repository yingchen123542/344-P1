//https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnCollide : MonoBehaviour
{
    public GameObject[] objectsToActivate;

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject thisObject in objectsToActivate)
        {
            thisObject.SetActive(true);
        }
    }
}
