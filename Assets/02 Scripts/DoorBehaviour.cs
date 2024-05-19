using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closeDoor;

    private bool isOpenable = true;
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player" && isOpenable){
            openDoor.SetActive(true);
            closeDoor.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player" && isOpenable){
            closeDoor.SetActive(true);
            openDoor.SetActive(false);
        }
    }
}
