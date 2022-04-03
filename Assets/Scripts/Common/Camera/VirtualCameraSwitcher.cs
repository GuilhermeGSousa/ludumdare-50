using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> camList;
    [SerializeField] private int initialCameraIndex = 0;

    private void Start() {
        SwitchToCamera(initialCameraIndex);
    }
    public void SwitchToCamera(int index)
    {
        if(index < 0 || index >= camList.Count) return;

        for (int i = 0; i < camList.Count; i++)
        {
            if(i == index) camList[i].Priority = 1;
            else camList[i].Priority = 0;
        }
    }
}
