using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTz : MonoBehaviour
{
    public float timenew = 3;
    public float Ymax=-2f;
    public float Ymin=2f;
    public GameObject Tz;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("newup", timenew, timenew);
    }
    void newup()
    {
        float y= Random.Range(Ymin, Ymax);
        Instantiate(Tz, new Vector2(10f, y), Quaternion.identity);
    }
}
