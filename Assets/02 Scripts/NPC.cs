using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] protected List<string> dialoguesCodes = new List<string>();
    protected int dialogueIndex = 0;
    bool playerInRange = false;

    // Update is called once per frame
    void Update()
    {
        //if (!playerInRange) return;

        CheckInput();
    }

    //Acciones dependiendo del estado del DialogueManager
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Si ya se terminaron los dialogos, se oculta la UI y se reinician los dialogos
            if (dialogueIndex >= dialoguesCodes.Count && !DialogueManager.Instance.isShowingDialogue)
            {
                EndConversation();
            }
            //Si no se estra mostrando ningun dialogo, se inician los dialogos.
            else if (!DialogueManager.Instance.isShowingDialogue)
            {
                DialogueManager.Instance.StartDialogue(dialoguesCodes[dialogueIndex]);
                dialogueIndex++;
            }
            // Si es esta mostrando un dialogo, se acompleta.
            else
            {
                DialogueManager.Instance.CompleteDialogue();
            }
        }
    }

    protected virtual void EndConversation()
    {
        DialogueManager.Instance.HideUI();
        dialogueIndex = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
