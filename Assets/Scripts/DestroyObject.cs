using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public GameObject objectToDestroy;
    public void DestroyObj()
    {
        Destroy(objectToDestroy);
    }

}