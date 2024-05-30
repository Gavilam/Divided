using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class LightBehaviour : MonoBehaviour
{
    [SerializeField] bool isDark = true;
    [SerializeField] float[] innerRadius;
    [SerializeField] float[] outterRadius;
    [SerializeField] Color[] colors;

    private Light2D lights;
    private int target = -1;

    void Start()
    {
        Events.TurnOnTheLights.AddListener(TurnOnLights);
        Events.ChangeCharacter.AddListener(ChangeCharacterLight);

        lights = GetComponent<Light2D>();
        if (isDark){
            lights.lightType = Light2D.LightType.Point;
            //lights.color = Color.black;
            ChangeCharacterLight();
        }
    }

    private void TurnOnLights(){
        isDark = false;
        lights.lightType = Light2D.LightType.Global;
        Events.ChangeCharacter.RemoveListener(ChangeCharacterLight);
    }

    private void ChangeCharacterLight(){
        target = (target + 1)%2;
        lights.pointLightInnerRadius = innerRadius[target];
        lights.pointLightOuterRadius = outterRadius[target];
        lights.color = colors[target];
    }

}
