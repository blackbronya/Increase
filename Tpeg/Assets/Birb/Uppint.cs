using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uppint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Bs>()!=null)
        {
            GameContlrol.instance.Birdescored();
        }
    }
}
