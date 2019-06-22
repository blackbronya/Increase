using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float shelltime;  //存在时间
    public float shellspeed; //速度
    public float shellsize; //判定大小
    public int Orientation; //朝向
    public GameObject boom; //爆炸动画
    public string Tag;//目标tag
    private void Start()
    {
        Destroy(gameObject, shelltime);//定时销毁
    }
    private void Update()
    {
        RaycastHit2D RAY = Physics2D.Raycast(transform.position, Vector2.up*Orientation, shellsize); //判定射线
        if(RAY.collider!=null&& !RAY.transform.CompareTag(Tag))
        {
            Instantiate(boom, transform.position, transform.rotation); //生成爆炸
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity=transform.up * shellspeed; //移动
    }
}
