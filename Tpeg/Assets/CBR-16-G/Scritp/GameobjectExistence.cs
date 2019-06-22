using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectExistence : MonoBehaviour
{
    public float time;
    void Start()
    {
        Destroy(gameObject, time);
    }
}
