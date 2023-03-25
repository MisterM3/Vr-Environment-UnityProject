using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInteractable : MonoBehaviour, IInteractable, IOnOffObject
{

    [SerializeField] private bool isOn = false;

    [SerializeField] Material lightOnMaterial;
    [SerializeField] Material lightOffMaterial;

    private Renderer rend;

    public void Start()
    {
        rend = GetComponent<Renderer>();

        if (isOn) On();
        else Off();
    }

    public void Interact()
    {
        if (isOn)
        {
            Off();
            isOn = false;
            return;
        }

        On();
        isOn = true;
    }

    public void Off()
    {
        rend.material = lightOffMaterial;
    }

    public void On()
    {
        rend.material = lightOnMaterial;
    }
}
