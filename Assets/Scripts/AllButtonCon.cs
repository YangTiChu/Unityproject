using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


//完成 
public class AllButtonCon : MonoBehaviour
{
    public GameObject CHscreen; //選關
    public GameObject Startscreen; //主頁面
    public GameObject SetPanel; //主頁面設定
    public GameObject MenuPage; //遊玩介面選單
    public GameObject Rulepage; //規則確認
    public GameObject Winpage; //勝利介面

    public VideoPlayer vp;
    public VideoClip[] clips;

    public int LVchoose;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //選關
    public void Lv1Click() //壹
    {
        Rulepage.SetActive(true);
        CHscreen.SetActive(false);
        Winpage.SetActive(false);
        LVchoose = 1;
        vp.clip = clips[0]; //0
    }
    public void Lv2Click() //貳
    {
        Rulepage.SetActive(true);
        CHscreen.SetActive(false);
        Winpage.SetActive(false);
        LVchoose = 2;
        vp.clip = clips[1]; //2
    }
    public void Lv3Click() //叁
    {
        Rulepage.SetActive(true);
        CHscreen.SetActive(false);
        Winpage.SetActive(false);
        LVchoose = 3;
        vp.clip = clips[2]; //4
    }

    //主頁面
    public void PlayClick() //開始
    {
        CHscreen.SetActive(true);
        Startscreen.SetActive(false);
    }
    public void ExitClick() //離開
    {
        Application.Quit();
    }
    public void SetClick() //設定
    {
        SetPanel.SetActive(true);
    }
    public void AboutClick() //關於
    {
        
    }
    public void BackClick() //關閉設定
    {
        SetPanel.SetActive(false);
    }
    

    //遊玩介面選單
        //離開在主頁面那
    public void HomeClick() //回主頁
    {
        Startscreen.SetActive(true);
        MenuPage.SetActive(false);
    }
    public void LVClick() //選關
    {
        CHscreen.SetActive(true);
        MenuPage.SetActive(false);
        Winpage.SetActive(false);
        Time.timeScale = 0f; //暫停
    }
    public void MenuClick() //目錄
    {
        Time.timeScale = 0f; //暫停
        MenuPage.SetActive(true);
    }
    public void CancelClick() //關閉目錄
    {
        MenuPage.SetActive(false);
        Time.timeScale = 1f; //繼續
    }
    
}
