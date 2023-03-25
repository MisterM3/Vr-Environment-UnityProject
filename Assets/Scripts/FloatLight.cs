using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class FloatLight : MonoBehaviour
{
    [SerializeField] private bool isOn = false;

    [SerializeField] Material lightOnMaterial;
    [SerializeField] Material lightOffMaterial;

    [SerializeField] XRLeverInteractable lever;
    private Renderer rend;


    public void Start()
    {
        rend = GetComponent<Renderer>();

        lever.floatEvent.AddListener(Lerp);
    }

    public void Lerp(float amount)
    {
        rend.material.Lerp(lightOffMaterial, lightOnMaterial, amount);
    }



}
