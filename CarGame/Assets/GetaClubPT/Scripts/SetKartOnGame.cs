using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKartOnGame : MonoBehaviour
{
    private GameObject kart_Player;
    private Transform kart_Transform;

    private GameObject cinematic_Camera;

    // Start is called before the first frame update
    void Start()
    {
        kart_Player = GameObject.Find("KartClassic_Player");
        cinematic_Camera = GameObject.Find("CinemachineVirtualCamera");

        //Reset Camera to follow custom kart
        cinematic_Camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = kart_Player.transform;
        cinematic_Camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = kart_Player.transform;

        // Reset Scripts

        kart_Player.GetComponent<Rigidbody>().useGravity = true;
        kart_Player.GetComponent<KartGame.KartSystems.ArcadeKart>().enabled = true;
        kart_Player.GetComponent<KartGame.KartSystems.KartPlayerAnimator>().enabled = true;
        kart_Player.GetComponent<KartGame.KartSystems.KartAnimation>().enabled = true;
        kart_Player.GetComponent<KartGame.KartSystems.KartBounce>().enabled = true;
        kart_Player.GetComponent<RotateOnAxis>().enabled = false;

        // Reset Position
        kart_Transform = kart_Player.GetComponent<Transform>();
        kart_Transform.position = new Vector3(15.94f, 1.01f, 1.5f);
        kart_Transform.rotation = Quaternion.Euler(0, 0, 0);
        kart_Transform.localScale = new Vector3(1, 1, 1);
        kart_Player.SetActive(false);
        kart_Player.SetActive(true);
    }
}
