using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolmove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
       transform.position = new Vector3(transform.position.x+16f, transform.position.y+1.5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>1)
           GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
    }
}
