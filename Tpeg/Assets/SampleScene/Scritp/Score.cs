using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreTexr; //获取文本UI
    public int ballValue; //分值
    public string Tag; //目标tgt
    int score;   //总分
    private void OnTriggerEnter2D(Collider2D collision) //触发器
    {
        score += ballValue;  //加分
        UpScore();  //调用改变分数显示方法
        Destroy(collision.gameObject);//删除物体
    }
    private void OnCollisionEnter2D(Collision2D collision) //碰撞体
    {    
        if (collision.transform.CompareTag(Tag))  //判断碰撞的物体
        {
            score -= ballValue*2; //减分
            UpScore(); //调用改变分数显示方法
        }
    }
    private void Start() //
    {
        score = 0; //赋值
        UpScore(); //调用方法
    }
    void UpScore()
    {
        ScoreTexr.text = "Score:\n" + score; //改变文本显示
    }
}
