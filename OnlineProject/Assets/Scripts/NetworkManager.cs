﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : Photon.PunBehaviour {

    public Text text;
    public GameObject loginUI;
    public InputField roomName;
    public Dropdown roomList;
	// Use this for initialization
	void Start () {
        //PhotonNetwork.logLevel = PhotonLogLevel.Full;

        PhotonNetwork.autoJoinLobby = false;

        PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
	void Update () {
        text.text = PhotonNetwork.connectionStateDetailed.ToString();
	}

    public override void OnJoinedLobby()
    {
        Debug.Log("ロビーに接続");
        loginUI.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("サーバに接続");
        loginUI.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("部屋に入りました");
        loginUI.SetActive(false);
        PhotonNetwork.Instantiate("Cube", Vector3.zero, Quaternion.identity, 0);
    }

    public void LoginGame()
    {
        RoomOptions ro = new RoomOptions();
        ro.IsVisible = true;
        ro.MaxPlayers = 10;
        if(roomName.text != "")
        {
            PhotonNetwork.JoinOrCreateRoom(roomName.text,ro,TypedLobby.Default);
        }
        else
        {
            if(roomList.options.Count != 0)
            {
                PhotonNetwork.JoinRoom(roomList.options[roomList.value].text);
            }
            else
            {
                PhotonNetwork.JoinOrCreateRoom("DefaultRoom",ro,TypedLobby.Default);
            }
        }
        Debug.Log("ログイン");
    }

    public void LogoutGame()
    {
        PhotonNetwork.LeaveRoom();
        loginUI.SetActive(true);
    }

    public override void OnReceivedRoomListUpdate()
    {
        Debug.Log("部屋更新");

        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        List<string> list = new List<string>();
        foreach(RoomInfo room in rooms)
        {
            if(room.PlayerCount < room.MaxPlayers)
            {
                list.Add(room.Name);
            }
        }
        roomList.ClearOptions();

        if(list.Count != 0)
        {
            roomList.AddOptions(list);
        }
    }
}
