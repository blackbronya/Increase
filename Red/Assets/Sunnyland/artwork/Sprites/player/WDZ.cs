using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WDZ : MonoBehaviour
{
    public HPKZQ H; //获取HP UI显示控制器
    Animator Anm;  //动画状态就
    private void Start()
    {
        Anm = GetComponent<Animator>(); //获取动画状态机
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MST") //判断是否撞到怪物
        {
            InvokeRepeating("WDSDM", 0, 2f); //开启无敌
            H.HD(); //hp减少
        }
    }
    int WDtime = 0; //阈值
    void WDSDM()
    {
        if (WDtime == 0)
        {
            gameObject.layer = 10;    //切换图层
            Anm.SetBool("WD", true);  //切换动画闪烁
            WDtime++; //+1
        }
        else
        {
            gameObject.layer = 8;     //切换图层
            WDtime = 0;               //重置
            Anm.SetBool("WD", false); //关闭动画
            CancelInvoke("WDSDM"); //关闭线程
        }
    }

    //hp增加
    public void HUU()
    {
        H.HU(); //hp的增加
    }
}
