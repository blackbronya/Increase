using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayUI : MonoBehaviour
{
    // Start is called before the first frame update
    int a=0;
    Animator Anm; //获取动画状态机
    void Start()
    {
        Anm = GetComponent<Animator>();  //获取动画状态就
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(a, GetComponent<Rigidbody2D>().velocity.y); //角色移动
    }
    // Update is called once per frame
    void Update()
    {
        Anm.SetBool("jump", true);  //可跳跃不添加次句会卡在跳跃动画无法切换
        if (a!=0)
            Anm.SetBool("run", true);  //移动动画切换
    }
    public void Uimove()
    { 
        a = -10;  //速度方向
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "St")   //判断是否撞到空气墙
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);   //场景切换加载
    }
}
