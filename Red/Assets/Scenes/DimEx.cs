using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimEx : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerAnm>().Plydia();  //死亡结束
    }
}
