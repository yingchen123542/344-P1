//https://gamedevbeginner.com/how-to-change-a-sprite-from-a-script-in-unity-with-examples/#change_sprite_from_script
//https://forum.unity.com/threads/how-to-find-the-x-and-y-axis-of-a-gameobject.89963/
//https://docs.unity3d.com/ScriptReference/Transform-position.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private int FIXED_UPDATES_BETWEEN_LETTERS = 2;
    private int FIXED_UPDATES_BETWEEN_SENTENCES = 80;

    private int fixedUpdateCount = 0;
    public TextMeshProUGUI dialogueText;
    // public GameObject screen;
    private Queue<char> sentence = new Queue<char>();

    public Animator animator;

    // public GameObject characterPortrait;

    // public GameObject namePlate;

    public GameObject[] objectsToSpawnAfterDialogue;

    public Queue<DialogueNode> dialogueNodes;
    public GameObject queuedDialogueChoice;
    public bool isTextSpedUp = false;
    [SerializeField]
    private AudioSource catTalk = null;
    private int shouldCatTalk = 0;
    private int playersTouching = 0;
    [SerializeField]
    private Collider2D thisCollider;



    public void StartDialogue (DialogueNode[] loadedDialogueNodes, GameObject[] afterDialogueObjects)
    {
        animator.SetBool("IsOpen", true);
        dialogueNodes = new Queue<DialogueNode>();
        sentence = new Queue<char>();


        dialogueNodes.Clear();


        foreach(DialogueNode dialogueNode in loadedDialogueNodes)
        {
            dialogueNodes.Enqueue(dialogueNode);
        }

        objectsToSpawnAfterDialogue = afterDialogueObjects;


        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (dialogueNodes.Count == 0)
        {
            EndDialgue();
            return;
        }

        DialogueNode currentDialogueNode = dialogueNodes.Dequeue();

        dialogueText.text = "";

        int i = 0;
                            Debug.Log("Is true:" + (i < currentDialogueNode.sentence.Length));
        while(i < currentDialogueNode.sentence.Length)
        {
            sentence.Enqueue(currentDialogueNode.sentence[i]);
            i++;
        }
        

        shouldCatTalk += 1;
    }
     
    void TypeSentence ()
    {
        dialogueText.text = "";

        DisplayNextSentence();
    }

    void FixedUpdate()
    {
        if (sentence.Count > 0)
        {
            if (fixedUpdateCount >= FIXED_UPDATES_BETWEEN_LETTERS)
            {
                dialogueText.text += sentence.Dequeue();
                fixedUpdateCount = 0;
            }

            if (shouldCatTalk > 1 && !catTalk.isPlaying)
            {
                catTalk.pitch = Random.Range(0.8f, 1.2f);
                catTalk.Play(0);
            }
        }
        else if (fixedUpdateCount >= FIXED_UPDATES_BETWEEN_SENTENCES)
        {
            Debug.Log("Yee: " + (fixedUpdateCount >= FIXED_UPDATES_BETWEEN_SENTENCES) + fixedUpdateCount);
            DisplayNextSentence();
            fixedUpdateCount = 0;
        }
        
        fixedUpdateCount += 1;
    }

    void EndDialgue()
    {
        dialogueText.text = "";

        foreach(GameObject myGameobject in objectsToSpawnAfterDialogue)
        {
            Instantiate(myGameobject);
        }

        animator.Play("Dialogue_Closed");
    }

}
