using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeNPC : NPC
{
    // En vez de reiniciar el dialogo, elimina el objeto
    protected override void EndConversation()
    {
        base.EndConversation();
        Destroy(gameObject);
    }
}
