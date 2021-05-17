using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class Highlight : MonoBehaviour
{
    private Material[] originalMaterials;
    private Material[] newMaterials;
    public Material highlightMaterial;

    void Start()
    {
        originalMaterials = GetComponent<MeshRenderer>().materials;
        newMaterials = GetComponent<MeshRenderer>().materials;
        for (int i = 0; i < newMaterials.Length; i++) {
            newMaterials[i] = highlightMaterial;
        }

        GetComponent<InteractionBehaviour>().OnContactBegin = delegate() {
            GetComponent<MeshRenderer>().materials = newMaterials;
        };
        GetComponent<InteractionBehaviour>().OnContactEnd = delegate() {
            GetComponent<MeshRenderer>().materials = originalMaterials;
        };
    }

    void Update()
    {
        
    }
}
