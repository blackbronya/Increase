using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sest : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] a;
    void Start()
    {
        a=GetComponentsInChildren<Transform>();
        StartCoroutine(AA());
    }
    IEnumerator AA()
    {
        foreach (Transform b in a)
        {

            yield return null;
        }
    }
}
