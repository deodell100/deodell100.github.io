using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Threading;


public class udp : MonoBehaviour
{
    UdpClient client;
    Thread recieveThread;

    // Use this for initialization
    void Start()
    {
        initthread();
    }

    private void initthread()
    {
        recieveThread = new Thread(new ThreadStart(RecieveData));
        recieveThread.IsBackground = true;
        recieveThread.Start();
        Debug.Log("Start");
    }

    private void RecieveData()
    {
        while (Thread.CurrentThread.IsAlive)
        {
            client = new UdpClient(5001);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] recieveBytes = client.Receive(ref RemoteIpEndPoint);
            string returndata = Encoding.ASCII.GetString(recieveBytes);
            Debug.Log(returndata);
        }
    }
    // Update is called once per frame
}