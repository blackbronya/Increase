using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMy : MonoBehaviour
{
    public Transform PLY; //获取玩家
    public GameObject UI1;
    public GameObject UI2;
    int a=0; //控制开启关闭
    private void Start()
    {
        Cursor.visible=false;//隐藏鼠标
    }
    void Update()
    {
        transform.position = new Vector3(PLY.position.x, transform.position.y, transform.position.z); //位置跟随
        if(Input.GetButtonDown("Cancel"))
        {
            UIUP(); //显示UI
        }
    }

    private void UIUP()
    {
        //是否显示UI和鼠标
        if (a != 1)
        {
            UI1.SetActive(true);
            UI2.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0.01f;
            a++;
        }
        else
        {
            UI1.SetActive(false);
            UI2.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            a = 0;
        }
    }
}
