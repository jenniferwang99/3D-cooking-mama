using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class MainMenuVoiceCommands : MonoBehaviour
{
    public GameObject egg;
    public GameObject introPanel;
    public GameObject reminderPanel;
    
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start() {
        Debug.Log("Starting keyword recognizer");
	    actions.Add("new egg", NewEgg);
        actions.Add("start game", StartGame);
        actions.Add("show instructions", ShowInstructions);

        actions.Add("close", ClosePanel);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void NewEgg()
    {
        Debug.Log("new egg incoming!");
	
        var x = Instantiate(egg, new Vector3(0.1f, 2, 0.4f),  Quaternion.identity);
        x.transform.parent = GameObject.Find("Interaction Objects").transform;
            
    }


    private void StartGame()
    {
        Debug.Log("going to cutting board");
	
        SceneManager.LoadScene (sceneName:"CuttingBoard");
            
    }

    private void ShowInstructions()
    {
        Debug.Log("go to tutorial!!");
        introPanel.SetActive(true);
        reminderPanel.SetActive(false);
    }

    private void ClosePanel() 
    {
        introPanel.SetActive(false);
        reminderPanel.SetActive(true);    
    }
}
