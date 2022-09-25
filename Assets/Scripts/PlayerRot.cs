using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerRot : MonoBehaviourPun
{
    public float rotSpeed = 205;

    public Transform camPos;

    float rotX;
    float rotY;


    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            camPos.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        rotX += mx * rotSpeed * Time.deltaTime;
        rotY += -my * rotSpeed * Time.deltaTime;

        transform.localEulerAngles = new Vector3(0, rotX, 0);
        camPos.localEulerAngles = new Vector3(rotY, 0, 0);
    }
}
