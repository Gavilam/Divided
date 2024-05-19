using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Remi;
    [SerializeField] GameObject Arkia;

    void Start()
    {
        Arkia.GetComponent<CharacterBehaviour>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
