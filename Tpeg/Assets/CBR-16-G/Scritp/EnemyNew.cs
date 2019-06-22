using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNew : MonoBehaviour
{
    Camera Cam;  //获取当前相机
    public GameObject[] Enemy; //获取敌人组
    public float SpeedMin;   //敌人生成速度最小
    public float SpeedMax;   //敌人生成速度最大
    System.Random ID = new System.Random(); //随机数只返回int类型的值
    private void Start()
    {
        Cam = Camera.main; //当前相机等于启用的相机
        StartCoroutine(ENew()); //开启协程
    }
    IEnumerator ENew()
    {
        yield return new WaitForSeconds(2.0f); //延迟0.2执行
        while (true)
        {
            Vector3 WH = new Vector3(Screen.width, Screen.height, 0); //获取相机的右上定点坐标
            Vector3 WH2 = new Vector3(Screen.width - Screen.width, Screen.height - Screen.height, 0); //获取相机左下的定点坐标
            Vector3 WWH = Cam.ScreenToWorldPoint(WH); //吧屏幕坐标转换为世界坐标
            Vector3 WWH2 = Cam.ScreenToWorldPoint(WH2);//吧屏幕坐标转换为世界坐标
            float X = Random.Range(WWH2.x, WWH.x);   //限制范围
            GameObject T= Instantiate(Enemy[ID.Next(0,Enemy.Length)], new Vector2(X,10), transform.rotation); //生成物体
            T.transform.parent = gameObject.transform;
            Destroy(T, 20f); //物体静置状态下的存在时间
            yield return new WaitForSeconds(Random.Range(SpeedMin,SpeedMax)); //下一次执行在0.5~2.0秒之间
        }  
    }
}
