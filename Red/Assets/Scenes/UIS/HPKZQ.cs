using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPKZQ : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Im;  //获取UI显示组
    public int ID=0;   //素组系数
    //private void Update()
    //{
    //    //测试用
    //    if (Input.GetMouseButtonDown(0))
    //        HD();
    //    if (Input.GetMouseButtonDown(1))
    //        HU();
    //}
    public void HD()
    {
        if (ID <= 2)
        {
            Im[ID].gameObject.SetActive(false);  //停用主键
            ID++;
        }
    }
    public void HU()
    {
        if (ID > 0)
        {
            ID--;
            Im[ID].gameObject.SetActive(true);   //启用主键
        }
    }
}
