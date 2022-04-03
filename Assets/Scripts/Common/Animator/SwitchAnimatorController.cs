using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimatorController : MonoBehaviour
{
    public bool isOn = false;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if(!animator) animator = GetComponent<Animator>();
        SetOn(isOn);
    }

    public void SetOn(bool on)
    {
        isOn = on;
        animator.SetBool("isOn", isOn);
    }

    public void TurnOn()
    {
        SetOn(true);
    }

    public void TurnOff()
    {
        SetOn(false);
    }
}
