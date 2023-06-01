using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;


//������  //���ܿO�����٨S�[ 
public class GestureJudgment : MonoBehaviour
{
    public GameObject Rulepage; //�W�h�T�{
    public GameObject Winpage; //�ӧQ����

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
        //�N�����쪺result���data�̡Awhile���ŭȳ���
        string data = TrackingResult.result;
        if (string.IsNullOrEmpty(data))
        {
            data = "[-1]";
        }
        //��ƳB�z �h��[]
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        //print(data);

        //�P�w�}�l
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
            //�����٨S�[
            count++;
        }
        print(count);
        if (count == 150)
        {
            if (LVC.LVchoose == 1) score = Evaluate(A);
            if (LVC.LVchoose == 2) score = Evaluate(B);
            if (LVC.LVchoose == 3) score = Evaluate(C);

            if (score == 10) eva = "�u";
            else if (score == 8) eva = "�}";
            else if (score == 5) eva = "�i";
            else  eva = "�t";

            TotalScore += score;
            Score.text = "����:" + TotalScore;
            Eva.text = eva;

            check = false;
            count = 0;
            Startimg.color = Color.red;
        }
        if (TotalScore >= 20)
        {
            Time.timeScale = 0f; //�Ȱ�
            Winpage.SetActive(true);
        }
    }

    public int Evaluate(int x) //����
    {
        if (x >= 105) x = 10; //70
        else if (x >= 75) x = 8; //50
        else if (x >= 45) x = 5; //30
        else x = 0;
        return x;
    }

    public void RuleClick() //�W�h�T�{���s
    {
        Score.text = "����:";
        //GameTime.text = "�ɶ� ";
        Eva.text = " ";
        TotalScore = 0;
        //time = 0;
        Rulepage.SetActive(false);
        Time.timeScale = 1f; //�~��
    }
}