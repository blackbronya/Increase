using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ee: MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 move = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody2D>().MovePosition(move);
        }
        if(Input.GetMouseButtonUp(0))
        {
            Invoke("En", 0.1f);
        }
    }
    void En()
    {
        GetComponent<SpringJoint2D>().enabled = false;
    }
}
