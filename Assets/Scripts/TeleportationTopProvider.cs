using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TeleportationTopProvider : TeleportationProvider
{

    [SerializeField] private Transform retical;
    [SerializeField] private float angle;

    //Teleports only if the angle is less that given angle
    public override bool QueueTeleportRequest(TeleportRequest teleportRequest)
    {
        currentRequest = teleportRequest;

        bool isRotationInRange = CheckRotations();
        
        validRequest = isRotationInRange;
        return isRotationInRange;
    }
    public bool CheckRotations()
    {
        Vector3 rotation = retical.rotation.eulerAngles;
        if (rotation.x < 360 -angle && rotation.x > angle) return false;
        if (rotation.z < 360 -angle && rotation.z > angle) return false;

        return true;
    }
}
