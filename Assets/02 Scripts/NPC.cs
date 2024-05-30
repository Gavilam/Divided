using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] DialogueType dialogueType;
    [SerializeField] protected List<string> dialoguesCodes = new List<string>();
    protected int dialogueIndex = 0;
    enum DialogueType { mainNarrative, docInfo, secondaryInfo }

    //[SerializeField] GameObject canvas;
    [SerializeField] Enums.Items[]  neccesaryItems;
    private bool isActivable = false;
    private bool isActive = false;
    
    void Update()
    {
        if (isActive){
            CheckInput();
        }
        else if (isActivable){
            if (Input.GetKeyDown(KeyCode.E)){
                ActivateDialogue();
            }
        }
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
                DialogueManager.Instance.StartDialogue(dialoguesCodes[dialogueIndex], (int)dialogueType);
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
        DisactivateDialogue();
        DialogueManager.Instance.HideUI();
        dialogueIndex = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActivable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DisactivateDialogue();
            isActivable = false;
        }
    }

    public void ActivateDialogue(){
        if(neccesaryItems.Length > 0){
            
        }
        //canvas.SetActive(true);
        isActive = true;
    }

    public void DisactivateDialogue(){
        //canvas.SetActive(false);
        isActive = false;
        DialogueManager.Instance.HideUI();
    }
}
