using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chop : MonoBehaviour
{
    private double TIMEOUT;
    private double chopTimeout;
    public GameObject slicedPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
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
	        Debug.Log("cutting whoooo!");
            var x = Instantiate(slicedPrefab, transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
            x.transform.parent = GameObject.Find("Interaction Objects").transform;
            Destroy(gameObject);

		    chopTimeout = Time.realtimeSinceStartupAsDouble;
	    }
	}
    }
}
