using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInt : MonoBehaviour
{
    public int pi; //分值
    public GameObject AA; //特效动画
    public bool PU = true; //交互开关
    private void OnTriggerEnter2D(Collider2D collision)  //触发函数
    {
        if (collision.gameObject.name == "Player") //判断是否碰撞到物体
        {
            if(pi<2)
                collision.gameObject.GetComponent<WDZ>().HUU();  //通过调用到无敌物体真获取定位hp显示变化
            if (PU)
                collision.gameObject.GetComponent<PinUP>().pin(pi);  //产生加分
            Instantiate(AA, transform.position, Quaternion.identity); //生成特效
            Destroy(gameObject);  //清除物体
        }
    }
}
