using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class VoiceChop : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    
    public GameObject slicedPrefab;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        actions.Add("chop", ChopCarrot);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        
    }

    
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    // Update is called once per frame
    void ChopCarrot()
    {
        var x = Instantiate(slicedPrefab, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
        x.transform.parent = GameObject.Find("Interaction Objects").transform;
        Destroy(gameObject);
    }
}
