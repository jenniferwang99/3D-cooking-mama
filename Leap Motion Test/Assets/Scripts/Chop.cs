using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chop : MonoBehaviour
{
    private double TIMEOUT;
    
    private int cutCounter;
    private double chopTimeout;
    public GameObject slicedPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HELLO");
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
	    if (collision.collider.tag == "blade") {
	        cutCounter += 1;
            Debug.Log("cutting whoooo!");
            var x = Instantiate(slicedPrefab, transform.position, transform.rotation);
            x.transform.parent = GameObject.Find("Interaction Objects").transform;
            Destroy(gameObject);

		    chopTimeout = Time.realtimeSinceStartupAsDouble;
	    }
	}
    }
}
