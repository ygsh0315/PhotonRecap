using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviourPun
{
    public float speed = 10;
    public float jumpPower = 3;
    public float yVelocity;
    public float gravity = -9.81f;
    public CharacterController cc;
    public Text nickName;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        nickName.text = photonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = h * transform.right + v * transform.forward;
        dir.Normalize();
        if (cc.isGrounded)
        {
            yVelocity = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }

        
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;


        cc.Move(dir * speed * Time.deltaTime);
        
    }
}
