using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TZove : MonoBehaviour
{
    Rigidbody2D Dm;
    // Start is called before the first frame update
    BoxCollider2D wide;
    float Boxwide;
    void Start()
    {
        Dm = GetComponent<Rigidbody2D>();
        wide = GetComponent<BoxCollider2D>();
        Boxwide = wide.size.x;
        Dm.velocity = new Vector2(GameContlrol.instance.Dmspeed, 0);
    }
    void Update()
    {
        if (GameContlrol.instance.gameove)
        {
            Dm.velocity = Vector2.zero;
        }
    }
}
