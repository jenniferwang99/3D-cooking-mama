using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCarrotCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        ProgressCounter progressCounter = canvas.GetComponent<ProgressCounter>();
        progressCounter.carrotCounter += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
