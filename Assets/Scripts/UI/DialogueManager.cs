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
    public GameObject screen;
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

                            Debug.Log(currentDialogueNode.sentence.Length);
                            Debug.Log(currentDialogueNode.sentence);


        int i = 0;
                            Debug.Log("Is true:" + (i < currentDialogueNode.sentence.Length));
        while(i < currentDialogueNode.sentence.Length)
        {
            sentence.Enqueue(currentDialogueNode.sentence[i]);
            i++;
        }
        
        // for(int i = 0; i < currentDialogueNode.sentence.Length; i++)
        // {
        //     sentence.Enqueue(currentDialogueNode.sentence[i]);
        //     Debug.Log("Yee");
        // }

        // foreach(char character in currentDialogueNode.sentence.ToCharArray())
        // {
        //     sentence.Enqueue(character);
        //     Debug.Log("Yee");
        // }

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

    public void AbruptEnd()
    {
        if (dialogueNodes.Count > 0)
        {
        DialogueNode abruptEnd = new DialogueNode();
            abruptEnd.sentence = "I'll get out of your fur -_-";
            dialogueNodes.Clear();
            dialogueNodes.Enqueue(abruptEnd);
            DisplayNextSentence(); 
        }
        
    }

    void OnTriggerEnter2D (Collider2D hitInfo) //https://forum.unity.com/threads/figuring-out-exactly-how-many-objects-are-touching-a-trigger-or-collider.70104/
    {
        if(hitInfo.gameObject.tag == "PC")
        {
          playersTouching += 1;
          //Debug.Log(isPlayerTouching);
        }
        SetOppacity();
    }

    void OnTriggerExit2D (Collider2D hitInfo)
    {
        if(hitInfo.gameObject.tag == "PC")
        {
          playersTouching -= 1;
        }
        SetOppacity();
    }

    void SetOppacity()
    {
        if (playersTouching > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            screen.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            screen.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

}
