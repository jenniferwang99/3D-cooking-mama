using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class SnapToHand : MonoBehaviour
{
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<MeshCollider>().isTrigger = false;
        if(GetComponent<InteractionBehaviour>().isGrasped) {
            this.transform.rotation = GetComponent<InteractionBehaviour>().graspingController.rotation;
            this.transform.position = GetComponent<InteractionBehaviour>().graspingController.position;
            rigidBody.isKinematic = true;
        }
        else
        {
            rigidBody.isKinematic = false;
        }
    }
}
