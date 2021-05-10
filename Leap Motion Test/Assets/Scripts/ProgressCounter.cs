using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCounter : MonoBehaviour
{
    public int carrotCounter;
    public int potatoCounter;

    private int lastCarrotCounter;
    private int lastPotatoCounter;

    public GameObject checkmarkPrefab;

    private Vector3 relativePos;

    // Start is called before the first frame update
    void Start()
    {
        carrotCounter = 0;
        potatoCounter = 0;
        relativePos = GameObject.Find("Instruction").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (carrotCounter != lastCarrotCounter) {
            if (carrotCounter == 1) {
                var x = Instantiate(checkmarkPrefab, relativePos + new Vector3(49, -2, 0), transform.rotation);
                x.transform.parent = GameObject.Find("Instruction").transform;
            }
            else if (carrotCounter == 2) {
                var x = Instantiate(checkmarkPrefab, relativePos + new Vector3(79, -2, 0), transform.rotation);
                x.transform.parent = GameObject.Find("Instruction").transform;
            }
            lastCarrotCounter = carrotCounter;
        }
        if (potatoCounter != lastPotatoCounter) {
            if (potatoCounter == 1) {
                var x = Instantiate(checkmarkPrefab, relativePos + new Vector3(109, -2, 0), transform.rotation);
                x.transform.parent = GameObject.Find("Instruction").transform;
            }
            else if (potatoCounter == 2) {
                var x = Instantiate(checkmarkPrefab, relativePos + new Vector3(139, -2, 0), transform.rotation);
                x.transform.parent = GameObject.Find("Instruction").transform;
            }
            lastPotatoCounter = potatoCounter;
        }
    }
}
