using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private double TIMEOUT;
    
    private int cutCounter;
    private double chopTimeout;
    public Mesh wholeCarrot;
    public Mesh choppedCarrot;

    // Start is called before the first frame update
    void Start()
    {
	Debug.Log("HELLO");
	GetComponent<MeshFilter>().mesh = wholeCarrot;
        cutCounter = 0;
	chopTimeout = Time.realtimeSinceStartupAsDouble;
	TIMEOUT = 0.5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
	if (Time.realtimeSinceStartupAsDouble - chopTimeout > TIMEOUT) {
	    if (collision.collider.tag == "knife") {
	        Debug.Log("cutting whoooo!");
	        cutCounter += 1;
	        if (cutCounter == 3) {
		    GetComponent<MeshFilter>().mesh = choppedCarrot;
		    cutCounter = 0;
	        }
		chopTimeout = Time.realtimeSinceStartupAsDouble;
	    }
	}
    }
}
