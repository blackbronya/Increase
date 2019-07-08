using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnm : MonoBehaviour
{
    Animator Anm; //动画状态机
    public GameObject UID;
    public GameObject HPUI;
    void Start()
    {
        //获取当前物体的动画状态机
        Anm = GetComponent<Animator>();
    }
    void Update()
    {
        //获取当前的很轴输入
        float a = Input.GetAxis("Horizontal");
        //变更玩家朝向
        if (a > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (a < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //移动动画控制
        if (Input.GetButton("Horizontal"))
            Anm.SetBool("run",true);
        if (Input.GetButtonUp("Horizontal"))
            Anm.SetBool("run", false);
        
        //角色的跳跃动画切换
        Anm.SetBool("jump", PlayerMove.Jsw);

        //下落动画的切换
        if (GetComponent<Rigidbody2D>().velocity.y < 0)
            Anm.SetBool("JumpD", true);
        else
            Anm.SetBool("JumpD",false);

        //蹲下动画的切换
        if(Input.GetKey(KeyCode.S))
            Anm.SetBool("crouch", true);
        else
            Anm.SetBool("crouch", false);
        
        //死亡动画切换
        if(HPUI.GetComponent<HPKZQ>().ID==3)
        {
            Plydia();  //死
        }
    }

    public void Plydia()
    {
        Anm.SetBool("Dia", true); //开启动画
        GetComponent<PlayerMove>().enabled = false;  //停用脚本
        GetComponent<Collider2D>().enabled = false;   //停用碰撞体
                                                      //GetComponent<BoxCollider2D>().enabled = false;  //停用碰撞体
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        UID.SetActive(true);
        Cursor.visible = true;//显示鼠标
    }
}
