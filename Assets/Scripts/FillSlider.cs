using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class FillSlider : MonoBehaviour
{
    [SerializeField] Image slider;
    [SerializeField] bool isStarted = true;
    [SerializeField] float changeAmount = 1f;
    [SerializeField] float startAmount = 100f;
    [SerializeField] UnityEvent onMin;
    [SerializeField] UnityEvent onMax;
    float currentAmount;
    // Start is called before the first frame update
    void Start()
    {
        currentAmount = startAmount;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFill();

        if(!isStarted) return;
        currentAmount += changeAmount * Time.deltaTime;

        if(currentAmount <= 0) onMin.Invoke();
        if(currentAmount >= 100) onMax.Invoke();
    }

    void UpdateFill()
    {
        slider.fillAmount = currentAmount / 100f;
    }

    public void SetAmount(float amount)
    {
        currentAmount = amount;
    }

    public void IncrementAmount(float amount)
    {
        currentAmount += amount;

        if(currentAmount >= 100) currentAmount = 100f;
    }

    public void SetStarted(bool isStarted)
    {
        this.isStarted = isStarted;
    }
}
