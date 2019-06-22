using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject boom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boom.GetComponent<GGboom>().Frequency = 3;
        boom.GetComponent<GGboom>().FW = 0.1f;
        Instantiate(boom, collision.transform.position, Quaternion.identity);
        Destroy(collision.transform.gameObject);
    }
}
