using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    int startWidth;
    int startTime;
    bool stoveOn;

    public Material on_burner;
    public Material off_burner;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        startWidth = 10;
        startTime = (int)Time.timeSinceLevelLoad;
        stoveOn = false;

        actions.Add("stove on", StoveOn);
        actions.Add("stove off", StoveOff);
        actions.Add("new vegetables", StartOver);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rect = transform.GetComponent<RectTransform>();
        if (stoveOn && transform.GetComponent<RectTransform>().rect.width < 120) {
            setWidth(rect, startWidth + (Time.timeSinceLevelLoad - startTime) * 10);
        }
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void StoveOn()
    {
        Debug.Log("stove turning on!");
	
        stoveOn = true;
        GameObject.Find("pan_burner").GetComponent<MeshRenderer>().material = on_burner;
        GameObject.Find("smoke_particles").GetComponent<ParticleSystem>().Play(true);
        startTime = (int) Time.timeSinceLevelLoad;
    }

    private void StoveOff()
    {
        Debug.Log("stove turning off!");
	
        stoveOn = false;
        GameObject.Find("pan_burner").GetComponent<MeshRenderer>().material = off_burner;
        GameObject.Find("smoke_particles").GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        startWidth = (int) transform.GetComponent<RectTransform>().rect.width;

        if (startWidth >= 90 && startWidth <= 105) {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void StartOver()
    {
        Debug.Log("restarting the stove timer!");

        startWidth = 10;
        startTime = (int) Time.timeSinceLevelLoad;
        setWidth(transform.GetComponent<RectTransform>(), startWidth + (Time.timeSinceLevelLoad - startTime) * 10);
    }

    // taken from https://stackoverflow.com/questions/26423549/how-to-modify-recttransform-properties-in-script-unity-4-6-beta
    void setSize(RectTransform trans, Vector2 newSize) {
        Vector2 oldSize = trans.rect.size;
        Vector2 deltaSize = newSize - oldSize;
        trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
    }
    void setWidth(RectTransform trans, float newSize) {
        setSize(trans, new Vector2(newSize, trans.rect.size.y));
    }
    void setHeight(RectTransform trans, float newSize) {
        setSize(trans, new Vector2(trans.rect.size.x, newSize));
    }
}