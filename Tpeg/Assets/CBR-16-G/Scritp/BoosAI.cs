using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosAI : MonoBehaviour
{
    public float speed; //移动速度
    public float Sb;   // 间距
    Camera Cam; //获取相机
    Vector2 Mov; //当前行进方向
    Vector2 Ll; //活动区域右上顶点
    Vector2 Ur;//活动区域左下顶点
    Vector3 Thv;//当前的坐标
    private void Start()
    {
        Cam = Camera.main; //当前启用相机
        Vector2 Hw1 = new Vector3(Screen.width, Screen.height); //获取相机的右定点坐标
        Vector2 Hw2 = new Vector3(Screen.width - Screen.width, Screen.height - Screen.height / 2); //获取相机的右定点坐标
        Ll = Cam.ScreenToWorldPoint(Hw1); //吧屏幕坐标转换为世界坐标
        Ur = Cam.ScreenToWorldPoint(Hw2);//吧屏幕坐标转换为世界坐标
        StartCoroutine(Vecter()); //开启定时改变移动方向随机
        transform.parent = GameObject.Find("monster box").transform;
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Mov * speed;  //移动
        float X = Mathf.Clamp(transform.position.x, Ur.x + Sb, Ll.x - Sb);  //限制范围
        float Y = Mathf.Clamp(transform.position.y, Ur.y + Sb, Ll.y - Sb);  //限制范围
        transform.position = new Vector2(X, Y); //限制范围
    }
    IEnumerator Vecter() //
    { 
        while (true)
        {
            Mov = Random.insideUnitCircle*speed; //方向
            yield return new WaitForSeconds(5f); //调用间隔
        }
    }
}
