using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DialoguerGui : MonoBehaviour
{

    private bool _showing;
    public Image image;
    public Text text;
    public GameObject continueButton;
    public GameObject choiceOne;
    public GameObject choiceTwo;

    private string _text;
    private string[] _choices;

    // Use this for initialization
    void Start()
    {
        Dialoguer.events.onStarted += onStarted;
        Dialoguer.events.onEnded += onEnded;
        Dialoguer.events.onTextPhase += onTextPhase;

        continueButton.GetComponent<Button>().onClick.AddListener(() => Dialoguer.ContinueDialogue());
        choiceOne.GetComponent<Button>().onClick.AddListener(() => Dialoguer.ContinueDialogue(0));
        choiceTwo.GetComponent<Button>().onClick.AddListener(() => Dialoguer.ContinueDialogue(1));
    }

    void Update()
    {
        if(!_showing)
        {
            text.enabled = false;
            image.enabled = false;
            continueButton.SetActive(false);
            choiceOne.SetActive(false);
            choiceTwo.SetActive(false);
            return;
        }

        text.enabled = true;
        image.enabled = true;
        text.text = _text;

        if(_choices == null)
        {
            continueButton.SetActive(true);
            choiceOne.SetActive(false);
            choiceTwo.SetActive(false);
        }
        else
        {
            continueButton.SetActive(false);
            choiceOne.SetActive(true);
            choiceOne.GetComponentInChildren<Text>().text = _choices[0];
            choiceTwo.SetActive(true);
            choiceTwo.GetComponentInChildren<Text>().text = _choices[1];
        }

    }

    private void onStarted()
    {
        _showing = true;
    }

    private void onEnded()
    {
        _showing = false;
    }

    private void onTextPhase(DialoguerTextData data)
    {
        _text = data.text;
        _choices = data.choices;
    }

}
