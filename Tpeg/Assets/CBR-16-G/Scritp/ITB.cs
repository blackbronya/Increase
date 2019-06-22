using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITB : MonoBehaviour
{
    bool Tr = true; //切换开关
    void OnWillRenderObject()
    {
        if (Tr) //判断是否操作
        { 
            gameObject.tag = "Enemy"; //改变物体Tag
            Tr = false; //切换
        }
    }
}
