using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolVR : MonoBehaviour
{

    public static ObjectPoolVR Instance;

    [SerializeField] GameObject objectInSlot;
    [SerializeField] Transform parent;

    [SerializeField] Vector3 offSet;
    
    GameObject newObject;

    public void PutObjectInSlot(GameObject newObject)
    {
        RemoveObject();

        objectInSlot = newObject;
        SpawnObject();
    }

    public void RemoveObject()
    {
        objectInSlot = null;
        Destroy(newObject);
    }

    public void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        SpawnObject();
    }


    public void SpawnObject()
    {
        if (objectInSlot == null) return;

        newObject = Instantiate(objectInSlot, parent);

        newObject.GetComponent<Rigidbody>().isKinematic = true;
        newObject.GetComponent<Rigidbody>().useGravity = false;

    }
}
