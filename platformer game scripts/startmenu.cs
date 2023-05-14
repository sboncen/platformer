using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour
{


    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.control.lives = 3;
    }

    public void ToStageSelector()
    {
        SceneManager.LoadScene("StageSelector");
       
    }
}
