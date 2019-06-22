using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLS : MonoBehaviour
{
    public GameObject LsUp;
    public GameObject Ls;
    private void Start()
    {
        InvokeRepeating("F", 10f, 10f);
    }
    void F()
    {
        GameObject T = Instantiate(LsUp, transform.position + new Vector3(0.4359f, -0.368f, 0), Quaternion.identity);
        GameObject T1 = Instantiate(LsUp, transform.position + new Vector3(-0.4359f, -0.368f, 0), Quaternion.identity);
        Destroy(T, 0.011f);
        Destroy(T1, 0.011f);
        Invoke("F1",0.011f);
    }
    void F1()
    {
        Instantiate(Ls, transform.position+new Vector3(0.4359f, -0.368f,0), Quaternion.identity);
        Instantiate(Ls, transform.position+new Vector3(-0.4359f, -0.368f, 0), Quaternion.identity);
    }
    
}
