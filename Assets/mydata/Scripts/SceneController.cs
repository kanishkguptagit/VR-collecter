using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void onPressStart()
    {
        SceneManager.LoadScene(1);
    }
    public void onPressQuit()
    {
        Application.Quit();
    }
    public void onPressPause()
    {
        SceneManager.LoadScene(0);
    }
}
