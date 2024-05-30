using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] OneTimeNPC initStory;
    void Start()
    {
        initStory.ActivateDialogue();
    }
        
    void Update()
    {
        
    }
}
