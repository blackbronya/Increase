using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locking : MonoBehaviour
{
    public string Box;//获取盒子
    public float Hfe; //刷新频率
    Transform[] PLY; //声明组件
    System.Random ID = new System.Random(); //随机目标
    int id;
    private void Start()
    {
        PLY = GameObject.Find(Box).GetComponentsInChildren<Transform>(); //获取组件
        if (PLY.Length > 1)
        {
            id = ID.Next(1, PLY.Length); //固定id
            if (gameObject.CompareTag("TTP"))
                GetComponent<CBR_P>().AP = true;
            if (!PLY[id].CompareTag("EnemyNot"))
                InvokeRepeating("Refresh", 0, Hfe); //开启线程 
            else
                Start();
        }
    }
    void Refresh()
    {
        try
        {
            transform.rotation = Quaternion.LookRotation(PLY[id].transform.position - transform.position, Vector3.up); //直线旋转
        }
        catch
        {
            Start();
        }
      
    }
}
