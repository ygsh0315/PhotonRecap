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

    //방 생성
    public void CreateRoom()
    {
        //방 옵션 세팅
        RoomOptions roomOptions = new RoomOptions();
         

        //최대 인원(0명이면 최대인원)
        roomOptions.MaxPlayers = 10;
        //룸 목록에 보이냐? 보이지 않느냐?
        roomOptions.IsVisible = true;
        //방을 만든다
        PhotonNetwork.CreateRoom("수빈", roomOptions, TypedLobby.Default);
    }

    //방 생성 완료
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
    }

    //방 생성 실패
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed, " + returnCode +", "+ message);
        //팝업.. 똑같은 이름이 있습니다. 다른 이름으로 만들어주세요.

        //방입장
        JoinRoom();
    }

    //방 입장
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("수빈");
        //PhotonNetwork.JoinRoom : 선택한 방에 들어갈 때
        //PhotonNetwork.JoinOrCreateRoom : 방이름 설정해서 들어가려고 할 때, 해당 이름으로 된 방이 없으면 방 생성후 입장
        //PhotonNetwork.JoinRandomOrCreateRoom : 랜덤방을 들어가려고 할 때,조건에 맞는 방이 없다면 내가 방을 생성 후 입장
        //PhotonNetwork.JoinRandomRoom : 램덤한 방 들어갈 때
    }

    //방 입장이 성공했을 때 호출되는 함수
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        PhotonNetwork.LoadLevel("GameScene");
    }
    //방 입장 실패시 호출되는 함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + ", " + message);
    }
}
