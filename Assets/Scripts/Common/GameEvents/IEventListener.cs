using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventListener
{
    void OnEventRaised();
}

public interface IEventListener<T>
{
    void OnEventRaised(T parameter);
}
