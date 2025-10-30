using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public TextScript dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger has been entered");
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueScript>().StartDialogue(dialogue);
    }

}