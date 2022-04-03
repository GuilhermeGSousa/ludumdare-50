using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakBehaviour : MonoBehaviour
{

    [SerializeField] private List<string> lines;
    [SerializeField] private GameObject speechBubble;
    bool isSpeaking = false;

    private int currentLine = 0;

    private void Awake() {
        isSpeaking = false;
        speechBubble.SetActive(isSpeaking);
    }

    public void nextLine()
    {
        if(currentLine < lines.Count)
        {
            isSpeaking = true;
        }
        else
        {
            isSpeaking = false;
        }
        
        speechBubble.SetActive(isSpeaking);
        if(currentLine < lines.Count)
        {
            speechBubble.GetComponent<SpeechBubble>().SetText(lines[currentLine]);
            currentLine++;
        }
        else
        {
            StopTalking();
        }

        
    }

    public void StopTalking()
    {
        isSpeaking = false;
        currentLine = 0;

        speechBubble.SetActive(isSpeaking);
    }
}
