using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public GameObject HP; //获取hp显示UI
    public float[] St;//固定位置y坐标
    public GameObject[] boss;
    int Stid = 0;
    int Bossid = 0;
    public float scrollSpeed; //偏移改变速度
    bool GoMvo; //偏移开关
    bool New;  //生成开关
    //Renderer Mr; //渲染
    public void Start()
    {
        GoMvo = true;
        New = false;
    }
    public void GoMvoOpen(bool TF)
    {
        GoMvo = TF; //改变偏移状态
        Invoke("ShutHPDisplay", 3f); //开启新线程
       
    }
    void ShutHPDisplay()
    {
        HP.SetActive(false); //关闭hp显示
    }
    private void FixedUpdate()
    {
        if (transform.position.y <= St[Stid])
        {
            //print("抵达目标点停止");
            GoMvo = false; //停止
            New = true; //生成开始
            if (Stid +1< St.Length) //判断是否超出索引范围
                Stid++; //改变系数
            else
                St[Stid]= St[Stid]-1; //当超数组后添加一个值
        }
        if (GoMvo)
            transform.position = new Vector3(0, transform.position.y - scrollSpeed, 0); //偏移
        if (New)
        {
            HP.SetActive(true);
            Instantiate(boss[Bossid],new Vector3(0,3,0), Quaternion.identity); //生成
            Bossid++;
            New = false; //生成关闭
        }
    }
}
