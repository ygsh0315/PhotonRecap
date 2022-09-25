using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.GameVersion = "1";
        //NameServer ����(AppId, GameVersion, ��������)
        PhotonNetwork.ConnectUsingSettings();
    }

    //������ ������ ���� ����, �κ� ����ų� �����Ҽ� ���� ���� 
    public override void OnConnected()
    {
        base.OnConnected();
        print("OnConnected");
    }

    //������ ������ ����
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print("OnConnectedToMaster");

        //�г��� ����
        PhotonNetwork.NickName = "����S2����" + Random.Range(1,10000);
        //�⺻ �κ� ����
        PhotonNetwork.JoinLobby();
        //Ư�� �κ� ����
        //PhotonNetwork.JoinLobby(new TypedLobby("�������� �κ�", LobbyType.Default));
    }

    //�κ� ���� ������ ȣ��
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("OnJoinedLobby");
        //LobbyScene���� �̵�
        PhotonNetwork.LoadLevel("LobbyScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
