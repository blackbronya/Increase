using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butt : MonoBehaviour
{
    public PlayUI A;
    public void Sta()
    {
        A.Uimove();  //按下button调用目标函数（狐狸的移动）
    }
}
