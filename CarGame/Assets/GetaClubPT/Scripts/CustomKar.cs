using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomKar : MonoBehaviour
{
    /* 
     * Parameters to selecte the color to change 
     * all the parts of the kart (Wheel, engine(kart), and driver)
    */
    [Header("Wheel Colors")]
    public Material[] wheelColors;
    [Header("Driver Colors")]
    public Material[] driverColors;
    [Header("Kart Colors")]
    public Material[] kartColors;

    /*
     * Private variables to get and change the part of the kart to change,
     * the materias of the kart selected through butons,
     * the current material that the object is displaying
     * and a counter to to know which is the material currently selected
    */
    private GameObject kartDisplay;
    private GameObject[] objectsToChangeMat;
    private Material[] materialToChange;
    private Renderer objMat;
    private int currentMat = 0;

    void Start()
    {
        /*
         * This avoid that the custom kart that the user made change when the scena change
         * avoiding the object being destroy.
        */
        kartDisplay = GameObject.Find("KartClassic_Player");
        DontDestroyOnLoad(kartDisplay);
    }

    /*
     * This method is responsable of selected all the objects that make up 
     * the wheels, that means the 4 wheels, and assigned them to the parameter objectsToChangeMat,
     * in case the parameter is already assigned it reset the parameter and reassign it. 
    */
    public void ChangeWheelColor()
    {
        materialToChange = wheelColors;
        objectsToChangeMat = new GameObject[4];
        objectsToChangeMat[0] = kartDisplay.transform.Find("KartWheels").transform.Find("WheelFrontLeft").gameObject;
        objectsToChangeMat[1] = kartDisplay.transform.Find("KartWheels").transform.Find("WheelFrontRight").gameObject;
        objectsToChangeMat[2] = kartDisplay.transform.Find("KartWheels").transform.Find("WheelrearLeft").gameObject;
        objectsToChangeMat[3] = kartDisplay.transform.Find("KartWheels").transform.Find("WheelsRearRight").gameObject;

        currentMat = 0;
    }

    /*
     * This method is responsable of selected all the objects that make up 
     * the Driver, and assigned them to the parameter objectsToChangeMat,
     * in case the parameter is already assigned it reset the parameter and reassign it. 
    */

    public void ChangeDriverColor()
    {
        materialToChange = driverColors;
        objectsToChangeMat = new GameObject[1];
        objectsToChangeMat[0] = kartDisplay.transform.Find("KartSuspension").transform.Find("PlayerIdle").transform.Find("Template_Character").gameObject;

        currentMat = 0;
    }

    /*
     * This method is responsable of selected all the objects that make up 
     * the kart engine, and assigned them to the parameter objectsToChangeMat,
     * in case the parameter is already assigned it reset the parameter and reassign it. 
    */
    public void ChangeKartColor()
    {
        materialToChange = kartColors;
        objectsToChangeMat = new GameObject[1];
        objectsToChangeMat[0] = kartDisplay.transform.Find("KartSuspension").transform.Find("Kart").transform.Find("Kart_Body").gameObject;

        currentMat = 0;
    }

    /*
     * This method is responsable of being able of select different
     * material with the left arrow and assign the material to the
     * objects selected.
    */
    public void ChangeLeft()
    {
        currentMat = currentMat - 1;
        int tempInt = Mathf.Abs(currentMat) % materialToChange.Length;

        for (int i = 0; i < objectsToChangeMat.Length; i++ )
        {
            objMat = objectsToChangeMat[i].GetComponent<Renderer>();
            objMat.material = materialToChange[tempInt];
        }
    }

    /*
     * This method is responsable of being able of select different
     * material with the right arrow and assign the material to the
     * object selected.
    */
    public void ChangeRight()
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
