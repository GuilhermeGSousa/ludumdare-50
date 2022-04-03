using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Lever : MonoBehaviour
{
    enum LeverPosition
    {
        Up,
        Down,
        Mid
    }
    [SerializeField] UnityEvent onUp;
    [SerializeField] UnityEvent onDown;
    LeverPosition leverPosition = LeverPosition.Mid;

    float startRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.localRotation.eulerAngles.x == 50 && leverPosition != LeverPosition.Down)
        {
            leverPosition = LeverPosition.Down;
            onDown.Invoke();
        }
        else if(transform.localRotation.eulerAngles.x == 310 && leverPosition != LeverPosition.Up)
        {
            leverPosition = LeverPosition.Up;
            onUp.Invoke();
        }
        else
        {
            leverPosition = LeverPosition.Mid;
        }
    }
}
