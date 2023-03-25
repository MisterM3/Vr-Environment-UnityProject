using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Magazine : MonoBehaviour
{

    [SerializeField] int ammoCount;

    //Uses one bullet, if afterwards the bullet had 0 or more bullets, we know that the magazine had a bullet before using this function.
    public bool TryUseAmmo()
    {   
        ammoCount--;
        return ammoCount >= 0;
    }

    public bool TryUseAmmo(out int ammoAmount)
    {
        ammoCount--;
        ammoAmount = ammoCount;
        return ammoCount >= 0;
    }

    public bool HasAmmo()
    {
        return ammoCount > 0;
    }



}
