using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGboom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boom; //获取爆炸
    public int Frequency;//次数
    public float FW; //范围
    public float TimeB;//爆炸持续时间&&下一次爆炸的时间
    void Start()
    {
        StartCoroutine(Boom()); //开启协程
    }
    IEnumerator Boom()
    {
        for (int a = Frequency; a >= 0; a--)
        {

            GameObject T = Instantiate(boom, new Vector2(transform.position.x, transform.position.y) +Random.insideUnitCircle*FW, Quaternion.identity); //生成爆炸
            Destroy(T, TimeB); //爆炸清除
            yield return new WaitForSeconds(TimeB/2); //下一发间隔
        }
        Destroy(gameObject,TimeB);//清除物体
    }
}
