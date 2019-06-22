using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBR_P : MonoBehaviour
{
    public GameObject Boo; //获取爆炸
    public float CBRtime; //子弹出现后最多存在时间
    public float BoomTime; //爆炸存着时间
    public float FlightSpeed; //飞行速度
    public string[] Tag; //攻击目标
    public float BodyMass; //炮弹的体积
    public int ShellDT = 1; //射线朝向
    public int Harm; //伤害值
    public bool AP=false; //是否为AP
    private void Start()
    {
        gameObject.transform.parent = GameObject.Find("Cartridge case").transform;
        Destroy(gameObject, CBRtime);//子弹出现后最多存在时间
    }
    private void FixedUpdate()
    {
        if (!AP)
            GetComponent<Rigidbody2D>().velocity = transform.up * FlightSpeed; //产生飞行的力量Y
        else
            GetComponent<Rigidbody2D>().velocity = transform.forward * FlightSpeed; //产生飞行的力量Z
        RaycastHit2D RAY = Physics2D.Raycast(transform.position, Vector2.up * ShellDT, BodyMass); //判定射线
        if (RAY.collider != null && Blast(RAY.transform))//判断是否碰撞到目标
        {
            if (RAY.transform.CompareTag("EnemyBoss")) //当被攻击物体是boos时，触发bosshp脚本
                RAY.transform.GetComponent<Bosshp>().HPDecrease(Harm); //触发bosshp脚本
            else                                    //当被攻击物体是不boos时，触发bosshp脚本
                RAY.transform.GetComponent<HP>().HPDecrease(); //触发HP脚本
            GameObject T = Instantiate(Boo, transform.position, Quaternion.identity);//产生爆炸动画
            Destroy(T, BoomTime); //动画播放存在时间
            Destroy(gameObject); //子弹删除
        }
    }
    bool Bstate; //爆炸状态
    bool Blast(Transform Co)
    {
        foreach (string T in Tag) //遍历所有会爆炸的目标
        {
            if (Co.CompareTag(T))  //如果是
            {
                Bstate = true;  //返回true 爆炸
                break; //跳出循环
            }
            else
            {
                Bstate = false;//返回false 不爆炸
            }
        }
        return Bstate; //返回爆炸于否
    }
}
