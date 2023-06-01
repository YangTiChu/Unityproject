using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

//�w�����Ű�
public class Tcp : MonoBehaviour
{
    //TCP port open
    Thread receiveThread;
    TcpClient client;
    TcpListener listener;
    int port;

    public RawImage img;
    byte[] imageDatas = new byte[0];
    Texture2D tex;

    void Start()
    {
        InitTcp();
        tex = new Texture2D(1280, 720);
    }

    void InitTcp()
    {
        port = 5066;
        print("TCP Initialized");
        IPEndPoint anyIP = new(IPAddress.Parse("127.0.0.1"), port);
        listener = new TcpListener(anyIP);
        listener.Start();

        receiveThread = new Thread(new ThreadStart(ReceiveData))
        {
            IsBackground = true
        };
        receiveThread.Start();
    }

    private void ReceiveData()
    {
        print("received somthing...");
        try
        {
            while (true)
            {
                client = listener.AcceptTcpClient();
                NetworkStream stream = new(client.Client);
                StreamReader sr = new(stream);
                //print(sr.ReadToEnd());
                string jsonData = sr.ReadLine();

                //Ū���Ϥ�
                Data _imgData = JsonUtility.FromJson<Data>(jsonData);
                imageDatas = _imgData.image;
            }
        }
        catch (Exception e)
        {
            print(e);
        }
    }

    public class Data
    {
        public byte[] image;
    }

    private void FixedUpdate()
    {
        //�ѩ�Unity���䴩�h�u�{�A�L�k�b������k�������]�wtexture�A�ҥH�bfixedUpdate���]�w�C
        tex.LoadImage(imageDatas);
        img.texture = tex;
    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
    }
}
