using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IEventListener
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent onEvent;

    private void OnEnable() {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable() {
        gameEvent.UnregisterListener(this);
    }
    public void OnEventRaised()
    {
        onEvent.Invoke();
    }
}
