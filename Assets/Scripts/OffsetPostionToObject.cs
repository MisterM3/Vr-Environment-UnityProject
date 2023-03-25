using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPostionToObject : MonoBehaviour
{

    [SerializeField] Transform objectFollow;

    [SerializeField] Transform objectChangePos;

    [SerializeField] Vector3 offset;

    [SerializeField] bool followPosX;
    [SerializeField] bool followPosY;
    [SerializeField] bool followPosZ;

    // Update is called once per frame
    void Update()
    {

        Vector3 position = Vector3.zero;

        if (followPosX)
        {
            position.x += objectFollow.position.x;
        }
        if (followPosY)
        {
            position.y += objectFollow.position.y;
        }
        if (followPosZ)
        {
            position.z += objectFollow.position.z;
        }

        objectChangePos.position = position + offset;

    }
}
