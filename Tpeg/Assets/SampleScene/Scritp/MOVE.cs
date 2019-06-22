using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MOVE : MonoBehaviour
{
    Camera Cam; //获取相机
    float X; //声明字段用于获取获得范围

    private void Start()
    {
        Cam = Camera.main;
        Vector3 WH = new Vector3(Screen.width, Screen.height, 0); //获取相机的右定点坐标
        Vector3 WWH = Cam.ScreenToWorldPoint(WH); //吧屏幕坐标转换为世界坐标
        X = WWH.x;//赋值给X现在物体X轴活动范围只能在屏幕内部
    }
    private void FixedUpdate()
    {
        Vector3 MO = Cam.ScreenToWorldPoint(Input.mousePosition);//获取鼠标按住在屏幕中的位置转换成在游戏内的世界坐标
                                                                 //z轴等于摄像组的位置
        float WWH = Mathf.Clamp(MO.x, -X, X); //锁定MO.x最大最小值
        GetComponent<Rigidbody2D>().MovePosition(new Vector3(WWH, transform.position.y, 0)); //将物体移动到坐标位置不会产生穿透
    }
}
