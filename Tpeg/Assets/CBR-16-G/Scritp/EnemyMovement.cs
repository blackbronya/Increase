using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed; //移动速度
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed); //敌人移动
        Vector2 Hw1 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2));
        if (transform.position.y < Hw1.y)
        {
            GetComponentsInChildren<Transform>()[0].GetComponentsInChildren<BossAT>()[0].Close();
        }
    }
}
