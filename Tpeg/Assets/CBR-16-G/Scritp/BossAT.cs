using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAT : MonoBehaviour
{
    public GameObject DT; //获取炮弹
    public Transform[] DTTF;   //获取炮口坐标
    public float AttackInterval; //攻击间隔
    public int Atint; //攻击次数
    private void Start()
    {
        InvokeRepeating("FS", AttackInterval, AttackInterval); //启动攻击协程
    }
    public void Close()
    {
        CancelInvoke("FS");
    }
    void FS() 
    {
        StartCoroutine(AT()); //开启线程
    }
    System.Random ID = new System.Random(); //只返回int的随机数
    IEnumerator AT() //开火线程
    {
        for(int a = Atint; a >= 0; a--) { 
            //随机一个位置生成
            Instantiate(DT, DTTF[ID.Next(0, DTTF.Length)].transform.position, DTTF[ID.Next(0, DTTF.Length)].transform.rotation); //生成炮弹
            yield return new WaitForSeconds(0.1f); //下一发的间隔
        }
    }
}
