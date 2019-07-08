using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Anm : MonoBehaviour
{
    public GameObject DiaAnm;
    Animator Anm; //声明动画状态机
    void Start()
    {
        //获取动画状态就
        Anm = GetComponent<Animator>();
    }
    void Update()
    {
        //根据跳跃状态切换
        Anm.SetBool("Jump", Gbm.Jsw);

        //角色的跳跃和下落状态动画切换
        if (GetComponent<Rigidbody2D>().velocity.y < 0)
            Anm.SetBool("JumoD",true);
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
            Anm.SetBool("JumoD", false);
        //角色的朝向
        transform.localScale = new Vector3(-Gbm.NA, 1, 1);      
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))  //判断是否被踩到
        {
            Instantiate(DiaAnm, transform.position, Quaternion.identity); //生成特效
            Destroy(gameObject); //清除物体
        }
    }
}
