using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressButton : MonoBehaviour
{
    [SerializeField] Transform button;
    [SerializeField] UnityEvent onPress;
    [SerializeField] UnityEvent onRelease;
    [SerializeField] float pressThresh = -0.07f;
    bool isPressed = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var localButtonPos = transform.InverseTransformPoint(button.position);

        if(localButtonPos.z <= pressThresh && !isPressed)
        {
            isPressed = true;
            onPress.Invoke();
        }
        else if(localButtonPos.z > pressThresh && isPressed)
        {
            isPressed = false;
            onRelease.Invoke();
        }
    }
}
