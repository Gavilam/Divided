using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityPCBehaviour : MonoBehaviour
{
    [SerializeField] GameObject turnedOnPC;
    [SerializeField] GameObject turnedOffPC;
    [SerializeField] GameObject triggerRecs;
    
    void Start()
    {
        Events.TurnOnTheLights.AddListener(TurnOnPC);
    }

    private void TurnOnPC(){
        turnedOffPC.SetActive(false);
        turnedOnPC.SetActive(true);
        triggerRecs.SetActive(true);
    }
}
