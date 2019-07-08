using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIN : MonoBehaviour
{
    Transform[] a;
    public GameObject UI;
    void Update()
    {
        a = GetComponentsInChildren<Transform>(); //获取子物体
        if(a.Length==1)
        {
            UI.SetActive(true); //显示结束UI
            Cursor.visible = true;//显示鼠标
        }
    }
}
