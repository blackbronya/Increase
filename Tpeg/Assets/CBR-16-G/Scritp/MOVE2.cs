using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE2 : MonoBehaviour
{
    Camera Cam; //获取相机
    public float Speed; //飞行速度
    private void Start()
    {
        Cam = Camera.main;
    }
    private void FixedUpdate()
    {
        float X = Input.GetAxis("Horizontal");   //获取输入横轴
        float Y = Input.GetAxis("Vertical");   //获取输入纵轴
        GetComponent<Rigidbody2D>().velocity = new Vector2(X * Speed, Y * Speed); //移动
        Vector3 WH = new Vector3(Screen.width, Screen.height, 0); //获取相机的右上定点坐标
        Vector3 WH2 = new Vector3(Screen.width - Screen.width, Screen.height- Screen.height, 0); //获取相机左下的定点坐标
        Vector3 WWH = Cam.ScreenToWorldPoint(WH); //吧屏幕坐标转换为世界坐标
        Vector3 WWH2 = Cam.ScreenToWorldPoint(WH2);//吧屏幕坐标转换为世界坐标
        float Xt = Mathf.Clamp(transform.position.x, WWH2.x+0.3f, WWH.x-0.3f);  //限制范围
        float Yt = Mathf.Clamp(transform.position.y, WWH2.y, WWH.y);  //限制范围
        transform.position = new Vector2(Xt, Yt); //限制范围
    }
}
