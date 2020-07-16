using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKartOnGame : MonoBehaviour
{
    /*
     * Private variables to get the kart which one the user will
     * play and to access to the transformation parameters of this one
    */
    private GameObject kartPlayer;
    private Transform kartTransform;

    /*
     * Private variable to get the cinematic Camera that flows and track 
     * the kartPlayer
   */
    private GameObject cinematicCamera;

    // Start is called before the first frame update
    void Start()
    {
        ResetSettingKartPlayer();
    }

    /*
     * This method is responsible of reseting all the parameters, scripts and features
     * that the kart has to put it in the start line and the cinematic Camera follow it. 
    */
    private void ResetSettingKartPlayer()
    {
        kartPlayer = GameObject.Find("KartClassic_Player");
        cinematicCamera = GameObject.Find("CinemachineVirtualCamera");

        //Reset Camera to follow custom kart
        cinematicCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = kartPlayer.transform;
        cinematicCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = kartPlayer.transform;

        // Reset Scripts
        kartPlayer.GetComponent<Rigidbody>().useGravity = true;
        kartPlayer.GetComponent<KartGame.KartSystems.ArcadeKart>().enabled = true;
        kartPlayer.GetComponent<KartGame.KartSystems.KartPlayerAnimator>().enabled = true;
        kartPlayer.GetComponent<KartGame.KartSystems.KartAnimation>().enabled = true;
        kartPlayer.GetComponent<KartGame.KartSystems.KartBounce>().enabled = true;
        kartPlayer.GetComponent<RotateOnAxis>().enabled = false;

        // Reset Position
        kartTransform = kartPlayer.GetComponent<Transform>();
        kartTransform.position = new Vector3(15.94f, 1.01f, 1.5f);
        kartTransform.rotation = Quaternion.Euler(0, 0, 0);
        kartTransform.localScale = new Vector3(1, 1, 1);
        kartPlayer.SetActive(false);
        kartPlayer.SetActive(true);
    }
}
