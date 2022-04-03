using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class SpeechBubble : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private Vector2 padding;
    [SerializeField] private float scrollDelay = 0.1f;

    [SerializeField] private Transform bubbleBase;
    [SerializeField] private Transform speakPoint;
    [SerializeField] private LineRenderer lineRenderer;
    

    private void Update() 
    {
        DrawLineRender();
    }

    public void SetText(string textInput)
    {
        text.SetText(textInput);
        UpdateBubble();
    }

    private void UpdateBubble()
    {
        StopCoroutine("ScrollText");
        text.gameObject.transform.position = transform.position;
        text.ForceMeshUpdate();

        Vector2 textSize = text.GetRenderedValues(false);
        background.size = textSize + padding;

        text.gameObject.transform.position += new Vector3(
            (background.size.x - textSize.x) / 2f,
            0f,
            0f
        );

        if(scrollDelay != 0) StartCoroutine("ScrollText", text.text);
    }

    IEnumerator ScrollText(string input)
    {
        text.text = "";

        foreach (char c in input)
        {
            text.text += c;
            yield return new WaitForSeconds(scrollDelay);
        }
    }

    private void DrawLineRender()
    {
        lineRenderer.positionCount = 2;
        
        lineRenderer.SetPosition(1, transform.InverseTransformPoint(bubbleBase.position));
        lineRenderer.SetPosition(0, transform.InverseTransformPoint(speakPoint.position));
    }
}
