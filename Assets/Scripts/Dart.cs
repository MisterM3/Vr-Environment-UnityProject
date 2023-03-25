using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    public void ResetDart()
    {
        rb.WakeUp();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") return;
        if (other.gameObject == this.gameObject) return;
        Debug.Log(other.gameObject);
        rb.velocity = Vector3.zero;
        rb.Sleep();
    }
}
