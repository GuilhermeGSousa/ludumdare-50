using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/GameEvent", order = 1)]
public class GameEvent : ScriptableObject
{
	private List<IEventListener> listeners = 
		new List<IEventListener>();

    public void Raise()
    {
        for(int i = listeners.Count -1; i >= 0; i--)
            listeners[i].OnEventRaised();
    }

    public void RegisterListener(IEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(IEventListener listener)
    { listeners.Remove(listener); }
}

[CreateAssetMenu(fileName = "FloatGameEvent", menuName = "Events/FloatGameEvent", order = 2)]
public class FloatGameEvent : GameEvent<float>
{
}

[CreateAssetMenu(fileName = "BoolGameEvent", menuName = "Events/BoolGameEvent", order = 3)]
public class BoolGameEvent : GameEvent<bool>
{
}


abstract public class GameEvent<T> : ScriptableObject
{
	private List<IEventListener<T>> listeners = 
		new List<IEventListener<T>>();

    public void Raise(T parameter)
    {
        for(int i = listeners.Count -1; i >= 0; i--)
            listeners[i].OnEventRaised(parameter);
    }

    public void RegisterListener(IEventListener<T> listener)
    { listeners.Add(listener); }

    public void UnregisterListener(IEventListener<T> listener)
    { listeners.Remove(listener); }
}