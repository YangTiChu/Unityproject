using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


//�w�����Ű�
public class HandTracking : MonoBehaviour
{
    //�NUDP=5056�������ƾڶǨ�ⳡ�ҫ��I�I�W
    public UDPReceive udpReceive;
    public GameObject[] handPoints;

    void Start()
    {

    }
    void Update()
    {
        string data = udpReceive.data;
        while (string.IsNullOrEmpty(data))
        {
            data = udpReceive.data;
        }
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        string[] points = data.Split(',');

        for (int i = 0; i < 21; i++)
        {

            float x = 7 - float.Parse(points[i * 3]) / 100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);

        }

    }
}
