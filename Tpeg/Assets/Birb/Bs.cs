using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bs : MonoBehaviour
{
    public Vector2 a;  //移动
    Animator Anm; //动画状态机
    // Start is called before the first frame update
    void Start()
    {
        Anm = GetComponent<Animator>(); //获取状态机
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Anm.SetTrigger("UP"); //触发动画
            GetComponent<Rigidbody2D>().AddForce(a); //活动Y轴正方向力
        }
        if (Input.GetMouseButtonUp(0))
        {
            Anm.SetTrigger("UP"); //再次触发回调动画
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //碰撞
    {
        print("///");
        Anm.SetBool("Di", true); //触发死亡动画
        GameContlrol.instance.Dis(); //停止滚动
    }
}
