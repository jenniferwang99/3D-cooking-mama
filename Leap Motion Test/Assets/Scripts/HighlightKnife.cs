using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class HighlightKnife : MonoBehaviour
{
    private Material[] originalMaterials;
    private Material[] originalBlade;
    private Material[] newMaterials;
    private Material[] newBlade;
    public Material highlightMaterial;

    void Start()
    {
        originalMaterials = GetComponent<MeshRenderer>().materials;
        originalBlade = GameObject.Find("blade").GetComponent<MeshRenderer>().materials;
        newMaterials = GetComponent<MeshRenderer>().materials;
        newBlade = GameObject.Find("blade").GetComponent<MeshRenderer>().materials;
        for (int i = 0; i < newMaterials.Length; i++) {
            newMaterials[i] = highlightMaterial;
            newBlade[i] = highlightMaterial;
        }

        GameObject.Find("knife").GetComponent<InteractionBehaviour>().OnContactBegin = delegate() {
            Debug.Log("begin!!!!");
            GetComponent<MeshRenderer>().materials = newMaterials;
            GameObject.Find("blade").GetComponent<MeshRenderer>().materials = newBlade;
        };
        GameObject.Find("knife").GetComponent<InteractionBehaviour>().OnContactEnd = delegate() {
            GetComponent<MeshRenderer>().materials = originalMaterials;
            GameObject.Find("blade").GetComponent<MeshRenderer>().materials = originalBlade;
        };
    }

    void Update()
    {
        
    }
}
