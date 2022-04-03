using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        float time = Mathf.Clamp(MetdownScreen.timeDifference, 0, Mathf.Infinity);
        text.text = "Good job comrade!\n Meltdown came " + time.ToString("0.00") + " seconds sooner because of you!";
    }
}
