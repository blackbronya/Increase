using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIdi : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI;
    void Start()
    {
        Invoke("OpUIRe", 0.5f);
    }
    void OpUIRe()
    {
        UI.SetActive(true);
    }
}
