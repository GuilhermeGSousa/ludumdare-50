using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> panels;

    public void SetPanel(int index)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(i == index);
        }
    }
}
