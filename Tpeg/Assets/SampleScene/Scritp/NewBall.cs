using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBall: MonoBehaviour
{
    // Start is called before the first frame update
    Camera Cam; //获取相机
    public GameObject[] Ball; //获取球
    public float Y;//设置生成物体高度
    public Text TimerText; //获取文本UI
    public float Text; //时间
    public GameObject GGUI;//获取游戏结束UI
    System.Random ID = new System.Random();
    float X; //获取获得范围x轴最大值
    int IDMAX;
    void Start()
    {
        Cam = Camera.main;
        Vector3 WH = new Vector3(Screen.width, Screen.height, 0); //获取相机的右定点坐标
        Vector3 WWH = Cam.ScreenToWorldPoint(WH); //吧屏幕坐标转换为世界坐标
        X = WWH.x;//赋值给X现在物体X轴活动范围只能在屏幕内部
        StartCoroutine(Spawn()); //开启线程
        IDMAX = Ball.Length;
    }
    private void Update()
    {
        Text -= Time.deltaTime; //当前事件减去过去的时间
        if(Text>0)
            TimerText.text = "Time\n" +Mathf.RoundToInt(Text); //改变显示
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f); //延迟2秒执行 后进入循环
        while (Text>0) {
            Vector3 Bomb = new Vector3(Random.Range(-X, +X), Y, 0); //产生一个随机坐标
            Instantiate(Ball[ID.Next(0,IDMAX)], Bomb, Quaternion.identity); //生成物体
        yield return new WaitForSeconds(Random.Range(1.0f, 2.0f)); //延迟1到 2秒再执行
        }
        GGUI.SetActive(true);
        Time.timeScale = 0;
    }
}
