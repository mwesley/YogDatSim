using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueInit : MonoBehaviour
{

    void Awake()
    {
        Dialoguer.Initialize();
    }

    public void DialogueStart()
    {
        Dialoguer.StartDialogue(3, dialoguerCallback);
        this.enabled = false;
    }

    private void dialoguerCallback()
    {
        this.enabled = true;
    }
}
