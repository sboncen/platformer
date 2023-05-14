using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void ClickQuit()
    {
        Application.Quit();
    }

    public void BTS()
    {
        SceneManager.LoadScene(0);
    }
}
