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
    public Mesh choppedCarrot1;
    public Mesh choppedCarrot2;
    public Mesh choppedCarrot3;
    public Mesh choppedCarrot4;
    public Mesh choppedCarrot5;
    public Mesh choppedCarrot6;
    public Mesh choppedCarrot7;
    public Mesh choppedCarrot8;
    public Mesh choppedCarrot9;
    public Mesh choppedCarrot10;
    public Mesh choppedCarrot11;
    public Mesh choppedCarrot12;
    public Mesh choppedCarrot13;
    public Mesh choppedCarrot14;
    public Mesh choppedCarrot15;
    public List<Mesh> carrotSlices;

    // Start is called before the first frame update
    void Start()
    {
    List<Mesh> carrotSlices = new List<Mesh>() {choppedCarrot1, choppedCarrot2, choppedCarrot3, choppedCarrot4, choppedCarrot5, choppedCarrot6, choppedCarrot7, choppedCarrot8};
    
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

    // public GameObject carrotSlicedPrefab;
    void OnCollisionEnter(Collision collision) {
	if (Time.realtimeSinceStartupAsDouble - chopTimeout > TIMEOUT) {
	    if (collision.collider.tag == "knife") {
	        cutCounter += 1;
            Debug.Log("cutting whoooo!");
            if (cutCounter == 1){
                GetComponent<MeshFilter>().mesh = choppedCarrot1;  
            }
	        
	        if (cutCounter > 8) {
                // Instantiate(fruitSlicedPrefab);
		        GetComponent<MeshFilter>().mesh = choppedCarrot;
		        
	        } else {
                GetComponent<MeshFilter>().mesh = carrotSlices[cutCounter];
            }
		chopTimeout = Time.realtimeSinceStartupAsDouble;
	    }
	}
    }
}
