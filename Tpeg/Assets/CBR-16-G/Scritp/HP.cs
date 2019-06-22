using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public int GameobjectHP; //物体hp
    public GameObject GGBoo; //死亡爆炸
    public GameObject HPUI; //获取hpUI显示条
    public Text TextHPvalue; //获取hpUI显示值
    public bool TurnOndisplay=false; //开启HP显示开关
    int Percentage; //每1%的HP的值
    int BloodlossED; //已经失去的hp量
    int IntHPvalue=100; //数值的hp
    private void Start()
    {
        Percentage = GameobjectHP / 100; //确认每1%的HP的值
    }
    public void HPIncrease()
    {
        GameobjectHP++;
    }
    public void HPDecrease()
    {
        GameobjectHP--;
        BloodlossED++;
        if(TurnOndisplay && BloodlossED==Percentage)
        {
            IntHPvalue--;
            BloodlossED = 0; //重置失去HP
            HPUI.GetComponent<RectTransform>().localScale = new Vector3(HPUI.GetComponent<RectTransform>().localScale.x-0.01f, 1, 1);//改变hp显示
            TextHPvalue.text = IntHPvalue.ToString() + "/100"; //改变显示
        }
        if (GameobjectHP<=0)
        {
            GameObject T= Instantiate(GGBoo,transform.position,Quaternion.identity); //生成死亡爆炸
            T.GetComponent<GGboom>().FW = 0.5f;
            T.GetComponent<GGboom>().Frequency = 10;
            Destroy(gameObject); //清除物体
        }
    }
}
