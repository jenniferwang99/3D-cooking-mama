using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("quit", Quit);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Quit()
    {
        Debug.Log("returning to main menu!");
	
        SceneManager.LoadScene("CuttingBoard");
    }
}
