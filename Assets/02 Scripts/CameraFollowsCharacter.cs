using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsCharacter : MonoBehaviour
{
    [SerializeField] Transform[] charactersTransform;
    [SerializeField] CharacterBehaviour[] charactersBehavior;
    [SerializeField] GameObject[] masks;

    private int target = 0;
    private float zCamera = -10;
    private bool isDark = true;

    void Start(){
        Events.ChangeCharacter.AddListener(ChangeCharacter);
    }
    void Update()
    {
        transform.position = new Vector3(charactersTransform[target].position.x, charactersTransform[target].position.y, zCamera);
    }

    private void ChangeCharacter(){
        charactersBehavior[target].enabled = false;
        if(isDark) masks[target].SetActive(false);
        target = (target + 1)%2;
        if(isDark) masks[target].SetActive(true);
        charactersBehavior[target].enabled = true;
    }

    private void FollowsRemi(){
        charactersBehavior[target].enabled = false;
        target = 0;
    }
    
    private void FollowsArkia875GT(){
        target = 1;
    }
}
