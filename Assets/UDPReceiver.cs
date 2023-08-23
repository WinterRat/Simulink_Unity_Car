
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using TMPro;

public class UDPReceiver : MonoBehaviour
{
    private UdpClient udpClient;
    private const int PORT = 25000;

    public TMP_Text displayText;

    public Transform FLW;
    public Transform FRW;
    public Transform RLW;
    public Transform RRW;
    public Renderer[] LEDs;

    public float FLW_angle;
    public float FRW_angle;
    public float RW_rpm;
    public float Velocity; // km/h
    public float Brake_state;

    private void Start()
    {
        udpClient = new UdpClient(PORT);
        udpClient.BeginReceive(ReceiveCallback, null);
    }

    private void ReceiveCallback(IAsyncResult ar)
    {
        IPEndPoint ep = new IPEndPoint(IPAddress.Any, PORT);
        byte[] receivedBytes = udpClient.EndReceive(ar, ref ep);

        ParseData(receivedBytes);

        udpClient.BeginReceive(ReceiveCallback, null);
    }

    private void ParseData(byte[] data)
    {
        if (data.Length > 5)
        {
            var str = System.Text.Encoding.Default.GetString(data);
            string[] messageParts = str.Split(',');
            FLW_angle = float.Parse(messageParts[0], CultureInfo.InvariantCulture);
            FRW_angle = float.Parse(messageParts[1], CultureInfo.InvariantCulture);
            RW_rpm = float.Parse(messageParts[2], CultureInfo.InvariantCulture);
            Velocity = float.Parse(messageParts[3], CultureInfo.InvariantCulture);
            Brake_state = float.Parse(messageParts[4], CultureInfo.InvariantCulture);

            //UnityEngine.Debug.Log($"FLW_angle: {FLW_angle}, FRW_angle: {FRW_angle}, RW_rpm: {RW_rpm}, Velocity: {Velocity}, Brake_state: {Brake_state}");
        }
        else
        {
            UnityEngine.Debug.LogWarning("Received unexpected number of values!");
        }
    }

    private void Update()
    {
        RotateWheels();
        MoveCar();
        UpdateDisplayText();
        // UpdateLEDs();
    }

    void RotateWheels()
    {
        // RPM to angle
        float rotationAmount = RW_rpm * Time.deltaTime * 360f;

        FLW.Rotate(Vector3.right, rotationAmount);
        FRW.Rotate(Vector3.right, rotationAmount);
        RLW.Rotate(Vector3.right, rotationAmount);
        RRW.Rotate(Vector3.right, rotationAmount);

        // Fix Wheel angle
        float averageFrontWheelAngle = (FLW_angle + FRW_angle) / 2;
        FLW.localEulerAngles = new Vector3(FLW.localEulerAngles.x, FLW_angle, FLW.localEulerAngles.z);
        FRW.localEulerAngles = new Vector3(FRW.localEulerAngles.x, FRW_angle, FRW.localEulerAngles.z);
        if (Velocity > 5)
        {
            transform.Rotate(Vector3.up, averageFrontWheelAngle * Time.deltaTime);
        }
    }

    void MoveCar()
    {
        float distanceToMove = Velocity * 1000f / 36f * Time.deltaTime; // km/h > m > dist
        transform.Translate(Vector3.forward * distanceToMove);
    }
    void UpdateLEDs()
    {
        /*        if (Brake_state > 0)
                {
                    foreach (LEDON led in FindObjectsOfType<LEDON>())
                    {
                        led.TurnOnEmission();
                    }
                }
                else
                {
                    foreach (LEDON led in FindObjectsOfType<LEDON>())
                    {
                        led.TurnOffEmission();
                    }
                }*/
    }
    void UpdateDisplayText()
    {
        if (displayText != null)
        {
            displayText.text = $"FLW_angle: {FLW_angle}¡Æ\nFRW_angle: {FRW_angle}¡Æ\nVelocity: {Velocity}km/h\nBrake_state: {Brake_state}";
        }
    }

    private void OnDestroy()
    {
        udpClient.Close();
    }
}