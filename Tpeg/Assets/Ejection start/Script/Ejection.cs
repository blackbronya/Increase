using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejection : MonoBehaviour
{
    public float maxStrectch = 1.0f; //长度限
    public LineRenderer catapultLineFront; //获取线渲染器
    public LineRenderer catapultLineBack;  //获取线渲染器
    bool ClickedOn; //事件状态
    float maxStretchSqr; //？？？？？
    float circleRadius; //圆的半径
    SpringJoint2D spring; //弹簧组件
    Ray2D RanToMove; //定义射线
    Ray2D LeftCatpultProjectile;
    Transform Catapult; //定义物体
    Vector2 prevVelocity;
    private void Start()
    {
        spring = GetComponent<SpringJoint2D>(); //获取组件
        Catapult = spring.connectedBody.transform; //获取坐标
        LineRendererSetup(); //调用方法
        RanToMove = new Ray2D(Catapult.position, Vector3.zero); //绘制射线
        LeftCatpultProjectile = new Ray2D(catapultLineFront.transform.position, Vector3.zero);//绘制射线
        maxStretchSqr = maxStrectch * maxStrectch; //？？？？？=长限制的平方
        CircleCollider2D circle = GetComponent<Collider2D>() as CircleCollider2D;
        circleRadius = circle.radius;

        GetComponent<Rigidbody2D>().isKinematic = true;//物体刚体受到物理约束
    }
    private void Update()
    {
        if (ClickedOn)//鼠标在物体上按下时
            Dragging(); //拖拽
        if(spring!=null)
        {
            if (!GetComponent<Rigidbody2D>().isKinematic &&prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude)
            {
                Destroy(spring);
                //spring.enabled = false;
                GetComponent<Rigidbody2D>().velocity = prevVelocity; //让物体获得速度
            }
            if (!ClickedOn)
                prevVelocity = GetComponent<Rigidbody2D>().velocity;//大小等于移动速度

            LineRendererupdate();
        }
        else
        {
            catapultLineFront.enabled = false;
            catapultLineBack.enabled = false;
        }
    }

    private void LineRendererupdate()
    {
        Vector2 cataoultToProiectie = transform.position - catapultLineFront.transform.position;//通过物体位置减去目标位置得到叉积
        LeftCatpultProjectile.direction = cataoultToProiectie; //射线方向等于叉积
        Vector3 holdPoint = LeftCatpultProjectile.GetPoint(cataoultToProiectie.magnitude + circleRadius);//沿射线获得一个指定点的距离，点在射线上；“cataoultToProiectie.magnitude”获取次向量的长度
        catapultLineFront.SetPosition(1, holdPoint);
        catapultLineBack.SetPosition(1, holdPoint);
    } 

    void Dragging()
    {
        Vector3 move = Camera.main.ScreenToWorldPoint(Input.mousePosition); //获取鼠标在场景中的位置
        Vector2 catapultTomove = move-Catapult.position; //到达鼠标位置，鼠标位置-物体位置
        if(catapultTomove.sqrMagnitude>maxStretchSqr) //比较平方弧度
        {
            RanToMove.direction = catapultTomove; //射线方向
            move = RanToMove.GetPoint(maxStretchSqr); //线距离长度
        }
        move.z = 0; //位置的z轴为0
        transform.position = move;
    }
    void LineRendererSetup()
    {
        catapultLineFront.SetPosition(0,catapultLineFront.transform.position); //线起始点
        catapultLineBack.SetPosition(0,catapultLineBack.transform.position); //线起始点
        catapultLineFront.sortingLayerName = "Foreground"; //改变渲染层
        catapultLineBack.sortingLayerName = "Foreground"; //改变渲染层
        catapultLineFront.sortingOrder = 3; //改变在层中的优先级
        catapultLineBack.sortingOrder = 1;//改变在层中的优先级
    }
    private void OnMouseDown() //鼠标放在挂脚本物体上按下时调用
    {
        spring.enabled = false; //关闭弹簧
        ClickedOn = true; //事件状态
    }
    private void OnMouseUp()//鼠标放在挂脚本物体上抬起时调用
    {
        spring.enabled = true; //开启弹簧
        GetComponent<Rigidbody2D>().isKinematic = false; //脱了物理控制
        ClickedOn = false; //事件状态
    }
}
