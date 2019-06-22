using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boom : MonoBehaviour
{
    public GameObject B; //获取爆炸动画
    public float BTime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject T = Instantiate(B, transform.position, Quaternion.identity); //生成爆炸动画
        Destroy(T,BTime); //动画持续时间
        Destroy(gameObject);//删除物体
    }
}
