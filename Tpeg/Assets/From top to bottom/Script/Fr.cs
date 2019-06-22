using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fr : MonoBehaviour
{
    public GameObject Shell;//炮弹
    public Transform[] AA; //生成位置
    public float As;  //速率
    public float Ad;   //延迟
    bool F;
    private void Start()
    {
        InvokeRepeating("FS", Ad, As);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            F = true;
        if (Input.GetMouseButtonUp(0))
            F = false;
    }
    void FS()
    {
        if (F)
            foreach (Transform a in AA)
            {
                Instantiate(Shell, a.position, transform.rotation).GetComponent<Shell>().Tag=gameObject.tag;
            }
    }
}
