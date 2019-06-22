using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rtt : MonoBehaviour
{
    public void GameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
} 
