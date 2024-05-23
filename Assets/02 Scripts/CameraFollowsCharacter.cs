using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsCharacter : MonoBehaviour
{
    [SerializeField] Transform[] charactersTransform;
    [SerializeField] CharacterBehaviour[] charactersBehavior;

    private int target = 0;
    private float zCamera = -10;

    void Start(){
        Events.ChangeCharacter.AddListener(ChangeCharacter);
    }
    void Update()
    {
        transform.position = new Vector3(charactersTransform[target].position.x, charactersTransform[target].position.y, zCamera);
    }

    private void ChangeCharacter(){
        charactersBehavior[target].enabled = false;
        target = (target + 1)%2;
        charactersBehavior[target].enabled = true;
    }
}
