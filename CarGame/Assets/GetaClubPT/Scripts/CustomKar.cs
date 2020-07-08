using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomKar : MonoBehaviour
{
    [Header("Wheel Colors")]
    public Material[] wheel_Colors;
    [Header("Driver Colors")]
    public Material[] driver_Colors;
    [Header("Kart Colors")]
    public Material[] kart_Colors;

    private GameObject kart_Display;
    private GameObject[] objectsToChangeMat;
    private Material[] materialToChange;
    private Renderer objMat;
    private int currentMat = 0;

    void Start()
    {
        kart_Display = GameObject.Find("KartClassic_Player");
        DontDestroyOnLoad(kart_Display);
    }

    public void changeWheelColor()
    {
        materialToChange = wheel_Colors;
        objectsToChangeMat = new GameObject[4];
        objectsToChangeMat[0] = kart_Display.transform.Find("KartWheels").transform.Find("WheelFrontLeft").gameObject;
        objectsToChangeMat[1] = kart_Display.transform.Find("KartWheels").transform.Find("WheelFrontRight").gameObject;
        objectsToChangeMat[2] = kart_Display.transform.Find("KartWheels").transform.Find("WheelrearLeft").gameObject;
        objectsToChangeMat[3] = kart_Display.transform.Find("KartWheels").transform.Find("WheelsRearRight").gameObject;

        currentMat = 0;
    }

    public void changeDriverColor()
    {
        materialToChange = driver_Colors;
        objectsToChangeMat = new GameObject[1];
        objectsToChangeMat[0] = kart_Display.transform.Find("KartSuspension").transform.Find("PlayerIdle").transform.Find("Template_Character").gameObject;

        currentMat = 0;
    }

    public void changeKartColor()
    {
        materialToChange = kart_Colors;
        objectsToChangeMat = new GameObject[1];
        objectsToChangeMat[0] = kart_Display.transform.Find("KartSuspension").transform.Find("Kart").transform.Find("Kart_Body").gameObject;

        currentMat = 0;
    }

    public void changeLeft()
    {
        currentMat = currentMat - 1;
        int tempInt = Mathf.Abs(currentMat) % materialToChange.Length;

        for (int i = 0; i < objectsToChangeMat.Length; i++ )
        {
            objMat = objectsToChangeMat[i].GetComponent<Renderer>();
            objMat.material = materialToChange[tempInt];
        }
    }

    public void changeRight()
    {
        currentMat = currentMat + 1;
        int tempInt = Mathf.Abs(currentMat) % materialToChange.Length;

        for (int i = 0; i < objectsToChangeMat.Length; i++)
        {
            objMat = objectsToChangeMat[i].GetComponent<Renderer>();
            objMat.material = materialToChange[tempInt];
        }
    }
}
