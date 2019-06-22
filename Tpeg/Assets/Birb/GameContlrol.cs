using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameContlrol : MonoBehaviour
{
    public static GameContlrol instance; //获取静态类
    public GameObject GameOveText;  //获取物体
    public bool gameove = false;
    public float Dmspeed = -1.5f;
    public Text scored; //获取记分ui
    float score; //分数
    private void Awake()
    {
        if (instance==null)  //当类容为空的时候
        {
            instance = this;  //那么等于当前
        }else if(instance!=null)
        {
            Destroy(gameObject); //删除物体
        }
    }
    private void Update()
    {
        if (gameove && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//获取当前活动场景

    }
    public void Birdescored()
    {
        if (gameove)
        {
            return;
        } 
        score++; //加分
        scored.text = "Score:" + score; //显示
    }
    public void Dis() //死亡显示ui
    {
        GameOveText.SetActive(true); //启用
        gameove = true; //返回true表示游戏结束
    }
}
