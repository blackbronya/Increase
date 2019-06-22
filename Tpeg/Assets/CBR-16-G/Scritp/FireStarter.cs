using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarter : MonoBehaviour
{
    public GameObject Bullet;//获取子弹
    public GameObject BulletAP;//获取子弹
    bool FireStarterState=false;//开火状态默认false
    bool FireStarterStateAP = false;//开火状态默认false
    bool AP=false;
    private void Start()
    {
        InvokeRepeating("FS", 0, 0.065f);
        InvokeRepeating("FSAP", 0, 0.1f);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //按下鼠标发射
        {
            FireStarterState = true;
            
        }
        if (Input.GetMouseButtonUp(0)) //抬起鼠标关闭
        {
            FireStarterState = false;
        }
        if (AP) {
            if (Input.GetMouseButtonDown(1)) //按下鼠标发射AP
            {
                FireStarterStateAP = true;

            }
            if (Input.GetMouseButtonUp(1)) //抬起鼠标关闭AP
            {
                FireStarterStateAP = false;
            }
        }
    }
    void FSAP()
    {
        if (FireStarterStateAP)//判定是否输入
        {
           GameObject T1 = Instantiate(BulletAP, transform.position + new Vector3(0.05f, 0f, 0), transform.rotation); //生成
            GameObject T2= Instantiate(BulletAP, transform.position + new Vector3(-0.05f, 0f, 0), transform.rotation); //生成
        }
    }
    void FS()
    {
        if (FireStarterState)//判定是否输入
        { 
            Instantiate(Bullet, transform.position + new Vector3(0, 0f, 0), transform.rotation); //生成
            Instantiate(Bullet, transform.position + new Vector3(0.1f, 0f, 0), transform.rotation); //生成
            Instantiate(Bullet, transform.position + new Vector3(-0.1f, 0f, 0), transform.rotation); //生成
        }   
    }
}
