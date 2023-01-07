using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
public class EndUiControl : MonoBehaviour
{

    public Text timeSpandText;
    public Text panel2BoxText;
    public Text panel2BottomText;
    private bool isTapped = false;
    public Image metalImage;
    public Sprite gold_m,silver_m,brown_m;
    

    public GameObject panel1, panel2;
    void Start()
    {
        timeSpandText.text = "恭喜你，花了：" + GM.s_timeUsed + "秒完成！";
    }
    /*
    void Update()
    {
        //點一下換頁
        if (!isTapped && Input.GetMouseButtonDown(0)) {
            //下一頁
            isTapped = true;
            panel1.SetActive(false);
            panel2.SetActive(true);

            //第二頁文字
            string _pre = GetPrecentage(GM.s_timeUsed).ToString();
            panel2BottomText.text = "您花費的時間排名為前" +_pre+ "%";
            panel2BoxText.text = "排名為前" + _pre + "%";
        }    
    }*/

    public void NextPage() {
        if (!isTapped)
        {
            //下一頁
            isTapped = true;
            panel1.SetActive(false);
            panel2.SetActive(true);

            //第二頁文字
            string _pre = GetPrecentage(GM.s_timeUsed).ToString();
            panel2BottomText.text = "您花費的時間排名為前" + _pre + "%";
            //panel2BoxText.text = "排名為前" + _pre + "%";

            if (GM.s_timeUsed <= 60) {
                metalImage.sprite = gold_m;
                panel2BoxText.text = "金牌";
            }
            else if (GM.s_timeUsed <= 90)
            {
                metalImage.sprite = silver_m;
                panel2BoxText.text = "銀牌";
            }
            else 
            {
                metalImage.sprite = brown_m;
                panel2BoxText.text = "銅牌";
            }/*
#if UNITY_WEBGL 
            CallAlert();
#endif*/
        }
    }

    private int GetPrecentage(int timeSpaned) {
        if (timeSpaned < 15) { return 2; }
        else if (timeSpaned < 20) { return 10; }
        else if (timeSpaned < 30) { return 20; }
        else if (timeSpaned < 40) { return 40; }
        else if (timeSpaned < 60) { return 50; }
        else { return 80; }
    }
    /*
    [DllImport("__Internal")]
    private static extern void CallAlert();*/

}
