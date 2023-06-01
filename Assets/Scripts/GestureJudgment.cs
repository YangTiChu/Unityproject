using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;


//未完成  //指示燈部分還沒加 
public class GestureJudgment : MonoBehaviour
{
    public GameObject Rulepage; //規則確認
    public GameObject Winpage; //勝利介面

    public UDPtrackingRec TrackingResult;
    public AllButtonCon LVC;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Eva;
    public GameObject Cimg;
    private Image Startimg;
    public bool check = false;
    private int count, A, B, C, F, score;
    private int TotalScore = 0;
    private string eva;
    void Start()
    {
        Startimg = Cimg.GetComponent<Image>();
        Startimg.color = Color.red;
    }

    void Update()
    {
        //將接收到的result放到data裡，while防空值報錯
        string data = TrackingResult.result;
        if (string.IsNullOrEmpty(data))
        {
            data = "[-1]";
        }
        //資料處理 去掉[]
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        //print(data);

        //判定開始
        if (data == "0" && check==false)  {
            check = true;
            count = 0;
            A= 0; B = 0; C = 0; F = 0; score = 0;
            Startimg.color = Color.green;
        }
        if (check) {
            if (data == "1") A++;
            else if (data == "2") B++;
            else if (data == "3") C++;
            else F++;
            //延遲還沒加
            count++;
        }
        print(count);
        if (count == 150)
        {
            if (LVC.LVchoose == 1) score = Evaluate(A);
            if (LVC.LVchoose == 2) score = Evaluate(B);
            if (LVC.LVchoose == 3) score = Evaluate(C);

            if (score == 10) eva = "優";
            else if (score == 8) eva = "良";
            else if (score == 5) eva = "可";
            else  eva = "差";

            TotalScore += score;
            Score.text = "分數:" + TotalScore;
            Eva.text = eva;

            check = false;
            count = 0;
            Startimg.color = Color.red;
        }
        if (TotalScore >= 20)
        {
            Time.timeScale = 0f; //暫停
            Winpage.SetActive(true);
        }
    }

    public int Evaluate(int x) //給分
    {
        if (x >= 105) x = 10; //70
        else if (x >= 75) x = 8; //50
        else if (x >= 45) x = 5; //30
        else x = 0;
        return x;
    }

    public void RuleClick() //規則確認按鈕
    {
        Score.text = "分數:";
        //GameTime.text = "時間 ";
        Eva.text = " ";
        TotalScore = 0;
        //time = 0;
        Rulepage.SetActive(false);
        Time.timeScale = 1f; //繼續
    }
}
