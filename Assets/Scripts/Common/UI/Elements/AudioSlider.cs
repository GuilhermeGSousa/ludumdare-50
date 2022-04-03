using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private string audioMixerParameter;
    [SerializeField] private AudioSettings audioSettings;

    private void Start() {
        audioSettings.audioMixer.GetFloat(audioMixerParameter, out float volume);
        GetComponent<Slider>().value = volume;
    }
}
