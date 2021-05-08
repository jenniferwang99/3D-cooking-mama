using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class SnapToHand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshCollider>().isTrigger = false;
        if(GetComponent<InteractionBehaviour>().isGrasped) {
            this.transform.rotation = GetComponent<InteractionBehaviour>().graspingController.rotation;
            this.transform.position = GetComponent<InteractionBehaviour>().graspingController.position;
        }
    }
}
