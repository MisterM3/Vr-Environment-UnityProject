using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    
    [SerializeField] bool inPoolSlot = true;

    public void CheckPooled()
    {

        if (!inPoolSlot) return;

        this.gameObject.GetComponent<Rigidbody>().WakeUp();
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        inPoolSlot = false;
        
        this.transform.SetParent(null, true);

    }

    public void SpawnNewObject()
    {
        if (!inPoolSlot) return;

        ObjectPoolVR.Instance.SpawnObject();
    }

    public void BoostUp()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * .003f);
    }

}
