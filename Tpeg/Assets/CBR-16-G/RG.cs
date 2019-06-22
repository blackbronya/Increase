using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG : MonoBehaviour
{
    public float Rmax;
    public float Rmin;
    private void FixedUpdate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float z = Mathf.Atan2((mousePosition.y - transform.position.y),
             (mousePosition.x - transform.position.x)) *
             Mathf.Rad2Deg - 90; //获得旋转
        //transform.eulerAngles = new Vector3(0, 0, z);//欧拉角旋转，当前是围绕z轴旋转

        //    print( System.Math.Abs(z));
        print(transform.rotation.z);
        if (transform.eulerAngles.z <= Rmax && transform.eulerAngles.z>=Rmin)
        {
            transform.eulerAngles = new Vector3(0, 0, z);
        }
        //else
        //{
        //    if (transform.eulerAngles.z > Rmax)
        //    {
        //        transform.eulerAngles = new Vector3(0, 0, Rmax);
        //    }
        //    if (transform.eulerAngles.z < Rmin)
        //    {
        //        transform.eulerAngles = new Vector3(0, 0, Rmin);
        //    }
        //}
       
        //if()
        //{
        //    if (transform.eulerAngles.z > Rmax)
        //        print("???x"+ z);
        //    if (transform.eulerAngles.z < Rmin)
        //        print("???n"+z);
        //}
    }
}
