using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceCommands : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start() {
        Debug.Log("HELLO");
	
        actions.Add("freeze", Freeze);
        actions.Add("unfreeze", Unfreeze);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        // Debug.Log(keywordRecognizer);
        
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
}
