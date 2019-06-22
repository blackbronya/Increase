using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMous : MonoBehaviour
{
    public float Speed;
    public Transform Player;
    private void FixedUpdate()
    {
        float z = Mathf.Atan2((Player.transform.position.y - transform.position.y),
            (Player.transform.position.x - transform.position.x))*
            Mathf.Rad2Deg + 90; //获得旋转
        //print(z);
        transform.eulerAngles = new Vector3(0, 0, z);//欧拉角旋转，当前是围绕z轴旋转
        GetComponent<Rigidbody2D>().AddForce(transform.up * Speed, ForceMode2D.Force);
    }
}
