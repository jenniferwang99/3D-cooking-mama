using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    Rigidbody rigidbody;
    public float maxVelocity = 3;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidbody.velocity.magnitude > maxVelocity)
        {
            rigidbody.velocity = maxVelocity * rigidbody.velocity.normalized;
        }
    }
}
