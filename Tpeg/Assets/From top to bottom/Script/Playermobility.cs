using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermobility : MonoBehaviour
{
    public float speed;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Attack");
        }
    }
    private void FixedUpdate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Quaternion rot = Quaternion.LookRotation(transform.position-mousePosition, Vector3.forward);
       // transform.rotation = rot;
        //transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z);

        float z = Mathf.Atan2((mousePosition.y - transform.position.y),
           (mousePosition.x - transform.position.x)) *
           Mathf.Rad2Deg - 90; //获得旋转\
        transform.eulerAngles = new Vector3(0, 0,z);


        GetComponent<Rigidbody2D>().angularVelocity = 0;
        float input = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed*input, ForceMode2D.Force);
    }
}
