using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD : MonoBehaviour
{
    // Start is called before the first frame update
    public float XSA; //时间阈值
    void Start()
    {
        Invoke("AA", XSA); //开启线程
    }
    void AA()
    {
        Destroy(gameObject); //清除物体
    }
}
