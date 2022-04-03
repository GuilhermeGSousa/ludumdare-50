using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    public float slowedTimeFactor = 0.5f;

    private bool updateFixedDeltaTime = false;


    public void StartSlowMo(float time)
    {
        StartCoroutine("SlowMoCoroutine", time);
    }

    public void SlowToStop(float timeToStop)
    {
        StartCoroutine("StopCoroutine", timeToStop);
    }

    public void StopTime(float time)
    {
        StartCoroutine("TimeStopCoroutine", time);
    }

    public void SpeedToNormal(float timeToNormal)
    {
        StartCoroutine("StartCoroutine", timeToNormal);
    }

    private void FixedUpdate() 
    {
        if(updateFixedDeltaTime)
        {
            updateFixedDeltaTime = false;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
    }

    IEnumerator SlowMoCoroutine(float time)
    {
        Time.timeScale = slowedTimeFactor;
        updateFixedDeltaTime = true;
        yield return new  WaitForSecondsRealtime(time);
        Time.timeScale = 1f;
        updateFixedDeltaTime = true;
        
    }

    IEnumerator TimeStopCoroutine(float time)
    {
        Time.timeScale = 0f;
        updateFixedDeltaTime = true;
        yield return new  WaitForSecondsRealtime(time);
        Time.timeScale = 1f;
        updateFixedDeltaTime = true;
        
    }

    IEnumerator StopCoroutine(float time)
    {
        float elapsedTime = 0f;
        while (elapsedTime < time)
        {
            Time.timeScale = Mathf.Lerp(1f, 0f, (elapsedTime / time));
            updateFixedDeltaTime = true;
            elapsedTime += Time.unscaledDeltaTime;
        
            yield return new WaitForSecondsRealtime(0);
        }
        Time.timeScale = 0;
        updateFixedDeltaTime = true;
    }

    IEnumerator StartCoroutine(float time)
    {
        float elapsedTime = 0f;
        while (elapsedTime < time)
        {
            Time.timeScale = Mathf.Lerp(0f, 1f, (elapsedTime / time));
            updateFixedDeltaTime = true;
            elapsedTime += Time.unscaledDeltaTime;
        
            yield return new WaitForSecondsRealtime(0);
        }
        Time.timeScale = 1;
        updateFixedDeltaTime = true;
    }

    private void OnDisable() {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }


}
