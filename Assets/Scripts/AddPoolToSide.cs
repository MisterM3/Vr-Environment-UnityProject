using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoolToSide : MonoBehaviour
{

    [SerializeField] GameObject objectToPool;



    public void AddObjectToPool()
    {
        ObjectPoolVR.Instance.PutObjectInSlot(objectToPool);
    }

    public void NewObjectToPool()
    {
        ObjectPoolVR.Instance.SpawnObject();
    }

    public void RemoveObjectFromPool()
    {
        ObjectPoolVR.Instance.RemoveObject();
    }
}
