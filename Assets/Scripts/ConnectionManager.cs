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
        //NameServer 접속(AppId, GameVersion, 지역정보)
        PhotonNetwork.ConnectUsingSettings();
    }

    //마스터 서버에 접속 성공, 로비를 만들거나 진입할수 없는 상태 
    public override void OnConnected()
    {
        base.OnConnected();
        print("OnConnected");
    }

    //마스터 서버에 접속
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print("OnConnectedToMaster");

        //닉네임 설정
        PhotonNetwork.NickName = "윤구S2수빈" + Random.Range(1,10000);
        //기본 로비 진입
        PhotonNetwork.JoinLobby();
        //특정 로비 진입
        //PhotonNetwork.JoinLobby(new TypedLobby("윤구수빈 로비", LobbyType.Default));
    }

    //로비 접속 성공시 호출
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("OnJoinedLobby");
        //LobbyScene으로 이동
        PhotonNetwork.LoadLevel("LobbyScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
