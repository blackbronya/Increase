using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Load : MonoBehaviour
{
    public Text A;
    public void LoadGame()
    {
        SceneManager.LoadScene(A.text, LoadSceneMode.Single);
    }
}
