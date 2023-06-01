using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

//已完成勿動
public class UDPReceive : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port = 5056;
    public bool startRecieving = true;
    public string data;

    void Start()
    {
        port = 5056;
        InitUDP();
    }

    private void InitUDP()
    {
        print("UDP Initialized");
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (startRecieving)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port);
                byte[] dataByte = client.Receive(ref anyIP);

                data = Encoding.UTF8.GetString(dataByte);

            }
            catch (Exception e)
            {
                print(e.ToString());
            }
        }
    }

    void Update()
    {

    }
}
