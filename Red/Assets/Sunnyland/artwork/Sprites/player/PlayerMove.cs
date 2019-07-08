using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PlayerSpeed;     //角色移动速度
    public float jumpPaw;         //角色跳跃力大小
    public Transform m_GroundCheck;  //通过这个坐标绘制圆判定角色的跳跃
    public LayerMask m_WhatIsGround; //通过这个来确认产生跳跃判断的图层
    const float k_GroundedRadius = .2f;  //判断的圆的半径
    public static bool Jsw;   //跳跃再执行状态
    private void FixedUpdate()
    {
        //角色的横向移动
        float a = Input.GetAxis("Horizontal") * PlayerSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(a, GetComponent<Rigidbody2D>().velocity.y);

        //角色的跳跃
        if (Jsw && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpPaw), ForceMode2D.Force);
            Jsw = false;  //跳跃状态false
        }
    }

    private void Update()
    {
        Jsw = false; //
        //吧圆击中的物体放入数组,此数组随着Update的刷新而重置
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);

        //遍历数数组中的元素
        foreach(Collider2D a in colliders)
        {
            //当其中物体不等于gameobject的时候跳跃状态等于true
            if (a.gameObject != gameObject)
            {
                Jsw = true;  
            }
        }
    }
}
