using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity.Interaction;


public class BetterGrabbing : MonoBehaviour
{
    Rigidbody rigidBody;
    
    private double TIMEOUT;
    private double graspTimeout;
    // Start is called before the first frame update
    void Start()
    {
        graspTimeout = Time.realtimeSinceStartupAsDouble;
        TIMEOUT = 0.5;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GetComponent<InteractionBehaviour>().isGrasped ) {
            this.transform.rotation = GetComponent<InteractionBehaviour>().graspingController.rotation;
            this.transform.position = GetComponent<InteractionBehaviour>().graspingController.position;
            rigidBody.isKinematic = true;
        }
        else
        {
            graspTimeout = Time.realtimeSinceStartupAsDouble;
        }
        
        if ((Time.realtimeSinceStartupAsDouble - graspTimeout) > TIMEOUT) 
        {
            rigidBody.isKinematic = false;
        }
        
    }
}
