using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Re : MonoBehaviour
{
    public void Resm()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameStat", LoadSceneMode.Single); //返回调用
    }
}
