using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        CreateRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�� ����
    public void CreateRoom()
    {
        //�� �ɼ� ����
        RoomOptions roomOptions = new RoomOptions();
         

        //�ִ� �ο�(0���̸� �ִ��ο�)
        roomOptions.MaxPlayers = 10;
        //�� ��Ͽ� ���̳�? ������ �ʴ���?
        roomOptions.IsVisible = true;
        //���� �����
        PhotonNetwork.CreateRoom("����", roomOptions, TypedLobby.Default);
    }

    //�� ���� �Ϸ�
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
    }

    //�� ���� ����
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed, " + returnCode +", "+ message);
        //�˾�.. �Ȱ��� �̸��� �ֽ��ϴ�. �ٸ� �̸����� ������ּ���.

        //������
        JoinRoom();
    }

    //�� ����
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("����");
        //PhotonNetwork.JoinRoom : ������ �濡 �� ��
        //PhotonNetwork.JoinOrCreateRoom : ���̸� �����ؼ� ������ �� ��, �ش� �̸����� �� ���� ������ �� ������ ����
        //PhotonNetwork.JoinRandomOrCreateRoom : �������� ������ �� ��,���ǿ� �´� ���� ���ٸ� ���� ���� ���� �� ����
        //PhotonNetwork.JoinRandomRoom : ������ �� �� ��
    }

    //�� ������ �������� �� ȣ��Ǵ� �Լ�
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        PhotonNetwork.LoadLevel("GameScene");
    }
    //�� ���� ���н� ȣ��Ǵ� �Լ�
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + ", " + message);
    }
}
