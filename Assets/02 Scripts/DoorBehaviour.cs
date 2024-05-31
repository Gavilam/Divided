using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closeDoor;
    [SerializeField] bool isOpenable = true;

    [SerializeField] Sprite lockedDoor;
    [SerializeField] Sprite interactableDoor;
    [SerializeField] GameObject openerEvent;

    public void Start(){
        if (!isOpenable){
            closeDoor.GetComponent<SpriteRenderer>().sprite = lockedDoor;
        }
        else{
            closeDoor.GetComponent<SpriteRenderer>().sprite = interactableDoor;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        if ((other.tag == "Arkia" || other.tag == "Remi") && isOpenable){
            openDoor.SetActive(true);
            closeDoor.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if ((other.tag == "Arkia" || other.tag == "Remi") && isOpenable){
            closeDoor.SetActive(true);
            openDoor.SetActive(false);
        }
    }

    public void SetDoorOpenable(){
        isOpenable = true;
        closeDoor.GetComponent<SpriteRenderer>().sprite = interactableDoor;
        if(openerEvent!=null) Destroy(openerEvent);
    }
}
