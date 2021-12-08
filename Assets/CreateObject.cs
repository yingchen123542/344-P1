using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject objectToCreate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void InstatiateObject()
    {
        Instantiate(objectToCreate, transform.position, transform.rotation);
    }
}
