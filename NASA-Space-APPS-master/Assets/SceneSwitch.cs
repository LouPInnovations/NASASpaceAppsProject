using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SW1()
    {
        SceneManager.LoadScene(0);
    }

    public void SW2()
    {
        SceneManager.LoadScene("Scene 2");
    }

    public void SW3()
    {
        SceneManager.LoadScene(sceneName: "Scene 2");
    }
}
