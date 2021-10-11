using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{ 

    public bool isTriggeredOnStart;
    public bool isSlightDelayBeforeDialogue;
    public DialogueNode[] dialogueNodes;

   public GameObject[] objectsToSpawnAfterDialogue;

    public void Start()
    {
        // if (isTriggeredOnStart && isSlightDelayBeforeDialogue)
        // {
        //     StartCoroutine(DelayStart());
        // }
        // else
        // {
            if (isTriggeredOnStart)
            {
                TriggerDialogue();
            }
        // }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueNodes, objectsToSpawnAfterDialogue);
    }
    public void Interact()
    {
        if (gameObject.tag == "InteractionObject")
        {
            TriggerDialogue();
        }
        gameObject.tag = "Untagged";
    }

    // IEnumerator DelayStart()
    // {
    //     if(PlayerPrefs.GetInt("isLevel1Unlocked") == 1)
    //     {
    //         yield return new WaitForSeconds(0.4f);
    //         TriggerDialogue();
    //     }
    //     else
    //     {
    //         yield return new WaitForSeconds(1.5f);
    //         TriggerDialogue();
    //     }
    // }
    
    
}
