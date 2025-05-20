using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Header("점프대")] 
    public float pushForce;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * pushForce, ForceMode.Impulse);
        }
    }
}
