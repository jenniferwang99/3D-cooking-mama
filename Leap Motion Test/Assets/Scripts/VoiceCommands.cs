using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceCommands : MonoBehaviour
{
    public GameObject wholeCarrot;
    public GameObject wholePotato;

    public GameObject knifePrefab;
    
    
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start() {
        Debug.Log("Starting keyword recognizer");
	    actions.Add("new potato", NewPotato);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void NewPotato()
    {
        Debug.Log("new potato incoming!");
	
        var x = Instantiate(wholePotato, new Vector3(0.1f, 2, 0.4f),  Quaternion.identity);
        x.transform.parent = GameObject.Find("Interaction Objects").transform;
            
    }
}
