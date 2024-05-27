using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeNPC : NPC
{
    // En vez de reiniciar el dialogo, elimina el objeto
    protected override void EndConversation()
    {
        DialogueManager.Instance.HideUI();
        Destroy(gameObject);
    }
}
