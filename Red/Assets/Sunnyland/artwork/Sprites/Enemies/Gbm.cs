using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gbm : MonoBehaviour
{
    public float PlayerSpeed; //Gbm的移动速度
    public float jumpPaw; //跳跃受到的力
    public Transform jumpif; //判定圆的圆心坐标点
    public LayerMask jumpiflaye; //判定产生的图层
    public LayerMask PLYL;     //怪物对这个图层的物体做出反应
    const float jumpifR = .2f; //判定圆的半径
    public float moveupif = 4f;  //反应范围
    public static bool Jsw;    //跳跃状态
    public Transform PLY; //获取玩家位置
    public static float NA = 1; //朝向取 1和-1；
    bool moveUP = false;  //是否做出反应开关
    private void Start()
    {
        InvokeRepeating("MoveUP", 0f, 1f);
    }
    void MoveUP()
    {
        //跳跃移动
        if (moveUP && Jsw) 
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPaw), ForceMode2D.Force);

            //通过判断目标的位置改变方向
            if (PLY.transform.position.x > transform.position.x)
                NA = 1;
            else if (PLY.transform.position.x < transform.position.x)
                NA = -1;
            //关闭跳跃
            Jsw = false;
        }
    }
    private void FixedUpdate()
    {
        //只有物体条起来了才受到方向力
        if (!Jsw)
            GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerSpeed * NA, GetComponent<Rigidbody2D>().velocity.y);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
    }
    private void Update()
    {
        Jsw = false;  //禁止跳跃
        moveUP = false;
        //跳跃判断
        Collider2D[] colliders = Physics2D.OverlapCircleAll(jumpif.position, jumpifR, jumpiflaye);
        foreach (Collider2D a in colliders)
        {
            if (a.gameObject != gameObject)
            {
                Jsw = true;
            }
        }
        //反应判断
        Collider2D[] moveUPif = Physics2D.OverlapCircleAll(jumpif.position, moveupif, PLYL);
        foreach (Collider2D a in moveUPif)
        {
            if (a.gameObject == PLY.gameObject)
            {
                moveUP = true;
            }
        }
    }
}
