using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    [SerializeField] DialogueType dialogueType;
    //[SerializeField] protected List<string> dialoguesCodes = new List<string>();
    [SerializeField] protected List<Dialogue> dialoguesCodes = new List<Dialogue>();
    protected int dialogueIndex = 0;
    enum DialogueType { mainNarrative, docInfo, secondaryInfo }

    [Serializable]
    public class Dialogue
    {
        [Serializable] public class DialogueEvent : UnityEvent<MonoBehaviour> { }
        public string dialoguesCode;
        public DialogueEvent OnDialogueBegin = new DialogueEvent();
    }

    [SerializeField] Enums.Items[]  neccesaryItems;
    private bool isActive = false;
    [SerializeField] bool isAutomatic = false;
    [SerializeField] bool Remi = true;
    [SerializeField] bool Arkia = true;
    
    void Start(){
        Events.ChangeCharacter.AddListener(DisactivateDialogue);
    }

    void Update()
    {
        if (isActive){
            CheckInput();
        }
    }

    //Acciones dependiendo del estado del DialogueManager
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ReadLine();
        }
    }

    private void ReadLine(){
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

    protected virtual void EndConversation()
    {
        DisactivateDialogue();
        dialogueIndex = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((Remi && collision.CompareTag("Remi")) || ( Arkia && collision.CompareTag("Arkia"))){
            if(isAutomatic){
                ReadLine();
            }
            ActivateDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((Remi && collision.CompareTag("Remi")) || ( Arkia && collision.CompareTag("Arkia")))
        {
            DisactivateDialogue();
        }
    }

    public void ActivateDialogue(){
        if(neccesaryItems.Length > 0){
            Debug.Log("item x");
        }
        isActive = true;
    }

    public void DisactivateDialogue(){
        isActive = false;
        DialogueManager.Instance.HideUI();
    }
}
