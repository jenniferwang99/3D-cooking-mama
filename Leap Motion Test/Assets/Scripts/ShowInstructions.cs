using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInstructions : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject reminderPanel;
    // Start is called before the first frame update
    void Start()
    {
        reminderPanel.SetActive(false);
        StartCoroutine("DelayClose");
    }
    IEnumerator DelayClose()
    {
        yield return new WaitForSeconds(10);
        introPanel.SetActive(false);
        reminderPanel.SetActive(true);
    }
    
}
