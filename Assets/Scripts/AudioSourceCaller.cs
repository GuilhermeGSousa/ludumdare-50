using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceCaller : MonoBehaviour
{
    [SerializeField] AudioSource source;

    public void Play()
    {
        source.Play();
    }
}
