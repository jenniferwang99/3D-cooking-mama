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
	
        actions.Add("freeze", Freeze);
        actions.Add("unfreeze", Unfreeze);
        actions.Add("new potato", NewPotato);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Freeze()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Unfreeze()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void NewPotato()
    {
        Debug.Log("new potato incoming!");
	
        var x = Instantiate(wholePotato);
        x.transform.parent = GameObject.Find("Interaction Objects").transform;
            
    }
}
