using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private string nextScene;
    public void SwitchSceneWithAnimation(string newScene)
    {
        nextScene = newScene;
        GetComponent<Animator>().SetBool("isOn", true);
    }

    public void SwitchToNextScene()
    {
        SwitchScene(nextScene);
    }

    public void SwitchScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}
