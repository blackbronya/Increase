using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosshp : MonoBehaviour
{
    public float GameobjectHP; //物体hp
    public GameObject GGBoo; //死亡爆炸
    public GameObject Hps; //获取hps实显示条
    public GameObject Hpx;  //获取hp虚显示条
    public Text TextHPvalue; //获取hp最大值UI显示值
    float Percentage; //每1%的HP的值
    int BloodlossED; //已经失去的hp量
    float IntHPvalue; //数值的hp
    float x; //差值
    float Dx;//减值
    private void Start()
    {
        Hps = GameObject.Find("Bosshps"); //获取hps实显示条
        Hpx = GameObject.Find("Bosshpx"); //获取hp虚显示条
        TextHPvalue = GameObject.Find("Bosshpv").GetComponent<Text>(); //获取hpUI显示值
        IntHPvalue = GameobjectHP; //hp最大值
        TextHPvalue.text = GameobjectHP + "/" + IntHPvalue.ToString(); //改变显示
        Percentage = GameobjectHP*0.001f; //确认每1%的HP的值
        Percentage = GameobjectHP/1000; //确认每1%的HP的值
        Hps.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //重置hp显示
        Hpx.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //重置hp显示
        InvokeRepeating("GteValue", 2f, 2f);//开启虚条变化
    }
    //hp增加
    public void HPIncrease()
    {
        GameobjectHP++;
    }
    //HP减少方法
    public void HPDecrease(int hp)
    {
        try
        {
            GameobjectHP -= hp; //hp减少
            BloodlossED += hp; //阈值增加
            TextHPvalue.text = GameobjectHP + "/" + IntHPvalue.ToString(); //改变显示
            if (BloodlossED >= Percentage) //抵达阈值上限
            {
                if (BloodlossED == Percentage)
                {
                    Hps.GetComponent<RectTransform>().localScale = new Vector3(Hps.GetComponent<RectTransform>().localScale.x - 0.001f, 1, 1);//改变hp显示
                    BloodlossED = 0;  //重置失去HP
                }
                else
                {
                    float a = BloodlossED / Percentage * 0.001f; //隐试转换舍去了小数部分
                    Hps.GetComponent<RectTransform>().localScale = new Vector3(Hps.GetComponent<RectTransform>().localScale.x -a, 1, 1);//改变hp显示
                    BloodlossED = 0;
                }
            }
            if (GameobjectHP <= 0) //死亡
            {
                GameObject T = Instantiate(GGBoo, transform.position, Quaternion.identity); //生成死亡爆炸
                T.GetComponent<GGboom>().FW = 2; //爆炸范围
                T.GetComponent<GGboom>().Frequency = 30; //爆炸次数
                GameObject.Find("map").GetComponent<Roll>().GoMvoOpen(true); //全局获取次物体
                GetComponent<PolygonCollider2D>().isTrigger = true; //关闭碰撞
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;//冻结刚体的运动
                gameObject.tag = "Wreckage"; //更改物体tag防止过度触发
                Destroy(gameObject, 3f); //清除物体
            }
        }
        catch (System.NullReferenceException)
        {
            Debug.Log("打空气");
        }
    }
    //HP虚条显示方法
    void GteValue()
    {
        x = Hpx.GetComponent<RectTransform>().localScale.x - Hps.GetComponent<RectTransform>().localScale.x; //用虚条减去实条得到差值
        Dx = x / 100; //差值的1%
        InvokeRepeating("DisplayChange", 0f, 0.01f); //开启协程
    }

    int a = 0;//定量减少次数
    //HP虚条显示方法
    void DisplayChange()
    {
        if (a < 100) //执行100次
        {
            //改变虚条显示
            Hpx.GetComponent<RectTransform>().localScale = new Vector3(Hpx.GetComponent<RectTransform>().localScale.x - Dx, 1, 1);
            a++; //次数减少
        }
        else
        {
            a = 0; //重置此次100次
            CancelInvoke("DisplayChange"); //关闭协程
        }
    }
}
