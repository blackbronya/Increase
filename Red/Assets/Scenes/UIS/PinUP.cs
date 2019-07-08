using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinUP : MonoBehaviour
{
    public Text P; //显示分
    int a;  //显示分的int对应值
    public void pin(int b)
    {
        a += b; //加分 b为物体的分数
        P.text = a.ToString()+"分";  //ui显示
    }
}
