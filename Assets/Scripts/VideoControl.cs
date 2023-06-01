using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Video;


//完成
public class VideoControl : MonoBehaviour
{
    public VideoPlayer vp;
    public VideoClip[] clips;
    private int CurrentVideo = 0;

    public AllButtonCon LVC;
    void Start()
    {
        vp.clip = clips[CurrentVideo];
    }

    // Update is called once per frame
    void Update()
    {

    }

    //影片尚未調整
    public void FrontVideo() //正
    {
        if (LVC.LVchoose == 1) CurrentVideo = 0;
        if (LVC.LVchoose == 2) CurrentVideo = 2;
        if (LVC.LVchoose == 3) CurrentVideo = 4;
        vp.clip = clips[CurrentVideo];
    }
    public void SideVideo() //測
    {
        if (LVC.LVchoose == 1) CurrentVideo = 1;
        if (LVC.LVchoose == 2) CurrentVideo = 3;
        if (LVC.LVchoose == 3) CurrentVideo = 5;
        vp.clip = clips[CurrentVideo];
    }
}
