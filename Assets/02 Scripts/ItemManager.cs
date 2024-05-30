using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Dictionary<Enums.Items, bool> itemsStates;

    void Start(){
        Events.ChangeItem.AddListener(SetItemState);
    }

    private void SetItemState(Enums.Items item){
        if (itemsStates.ContainsKey(item)){
            itemsStates[item] = true;
        }
    }

    public bool CheckItemState(Enums.Items item){
        if(itemsStates.ContainsKey(item)){
            return itemsStates[item];
        }
        else{
            return false;
        }
    }
    
}
