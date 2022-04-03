using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameObject(typeof(T).ToString() + "Singleton").AddComponent<T>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    public static void DestroyInstance()
    {
        _instance = null;
    }
 
    
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
        
    }

    protected void OnDestroy() 
    {
        Destroy(gameObject);
        DestroyInstance();
    }
}
