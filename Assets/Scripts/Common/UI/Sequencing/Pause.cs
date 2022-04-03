using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] private GameEvent<bool> gamePauseEvent;
    [SerializeField] private UnityEvent<bool> gamePauseUnityEvent;

    public void OnPause(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            SetPaused(true);       
        }

    }

    public void SetPaused(bool pause)
    {
        isPaused = pause;

        if(isPaused)
        {
            //playerInput.actions.FindActionMap("Movement").Disable();
            Time.timeScale = 0f;
        }
        else
        {
            //playerInput.actions.FindActionMap("Movement").Enable();
            Time.timeScale = 1f;
        }
        gamePauseEvent.Raise(pause);
        gamePauseUnityEvent.Invoke(pause);

    }
}
