using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float lifeTime = 20f;
    [SerializeField] private bool destroyOnStart = true;
    [SerializeField] private bool fadeOut = true;
    // Start is called before the first frame update
    void Start()
    {
        if(destroyOnStart) StartLifetime();
    }

    public void StartLifetime()
    {
        if(fadeOut)
        {
            StartCoroutine("FadeOutDestroy");
        }
        else
        {
            Destroy(gameObject, lifeTime);
        }
    }

    private IEnumerator FadeOutDestroy()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color startColor = renderer.material.color;
        for (float t=0f; t < lifeTime; t+=Time.deltaTime) 
        {
            float normalizedTime = t / lifeTime;

            renderer.material.color = Color.Lerp(startColor, Color.clear, normalizedTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}
