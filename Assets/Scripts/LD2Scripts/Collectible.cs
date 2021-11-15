//CPCS 344 - Level Design II, Chapman University, Fall 21
//Script reference : https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html 
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject [] objectsToDeactivate;
    public GameObject [] objectsToActivate;
    //Upon a collider hitting the trigger, this collectible will be destroyed
    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject thisObject in objectsToActivate)
        {
            thisObject.SetActive(true);
        }

         foreach(GameObject thisObject in objectsToDeactivate)
        {
            thisObject.SetActive(false);
        }
    }

}
