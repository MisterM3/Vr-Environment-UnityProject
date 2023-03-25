using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject teleportRay;
    public InputActionProperty activateTeleport;

    // Update is called once per frame
    void Update()
    {
        teleportRay.SetActive(activateTeleport.action.ReadValue<float>() > 0.1f);
    }
}
