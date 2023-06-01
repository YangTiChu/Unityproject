using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;


//¥¼§¹¦¨
public class UDPtrackingRec : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port = 5076; 
    public bool startRecieving = true;
    public string result;

    void Start()
    {
        port = 5076;
        InitUDP();
    }

    private void InitUDP()
    {
        print("UDPtracking Initialized");
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

                result = Encoding.UTF8.GetString(dataByte);
                //print(result);

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
