using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vat : MonoBehaviour
{
    //相机跟谁移动的脚本
    public Transform CBR;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Vector3 Mv = CBR.position;
        float Mx = Mathf.Clamp(Mv.x, -37, 37); //锁定MO.x最大最小值
        float My = Mathf.Clamp(Mv.y, -44, 44);  
        GetComponent<Rigidbody2D>().MovePosition(new Vector3(Mx, My, 0)); 
    }
}
