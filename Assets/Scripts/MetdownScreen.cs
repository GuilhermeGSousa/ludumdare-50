using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class MetdownScreen : MonoBehaviour
{
    public static float timeDifference;
    [SerializeField] private TMP_Text text;
    [SerializeField] float totalTime = 300f;
    [SerializeField] UnityEvent onTimeOut;
    float currentTime;
    float timer = 0;
    bool isOver = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = totalTime;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        currentTime -= Time.deltaTime;

        timeDifference = totalTime - timer;

        if(!isOver)
        {

        text.text = 
            "Time to Meltdown: \n" + currentTime.ToString("0.00");
        } 

        if(currentTime <= 0 && !isOver)
        {
            isOver = true;
            onTimeOut.Invoke();

            text.text = 
            "CORE CRITICAL \n\n THIS IS GOING TO HURT" ;
        }
    }


    public void ResetTimer()
    {
        currentTime = totalTime;
    }

    public void AddToTimer(float time)
    {
        currentTime += time;
    }

}
