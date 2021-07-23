using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class ConnectArduino : MonoBehaviour
{
    SerialPort stream;
   

    // shared instance for the game
    private static ConnectArduino sharedInstance;
    private void Awake()
    {
        sharedInstance = this;
    }

    public static ConnectArduino GetInstane()
    {
        return sharedInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        stream = new SerialPort("COM2", 9600);
        stream.ReadTimeout = 50;
        stream.Open();

    }

    public void WriteToArduino(string message)
    {
        Debug.Log("sent");
        stream.WriteLine(message);
        stream.BaseStream.Flush();
    }
}
