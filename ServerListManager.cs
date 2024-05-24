using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Photon.Pun;
using System.Collections.Generic;

public class ServerListManager : MonoBehaviour
{
    public GameObject serverPrefab;
    public Transform serverListContent;
    public RoomListManager roomListManager;


    void Start()
    {
        roomListManager = FindObjectOfType<RoomListManager>();
        if (roomListManager == null)
        {
            Debug.LogError("RoomListManager not found in the scene.");
            return;
        }

        List<RoomInfo> availableRooms = roomListManager.GetAvailableRooms(4, 2);

        // �������� ������� ��� ������� �������
        foreach (RoomInfo roomInfo in availableRooms)
        {
            GameObject serverItem = Instantiate(serverPrefab, serverListContent);
            ServerInfoDisplay serverDisplay = serverItem.GetComponent<ServerInfoDisplay>();

            // ��������������� ���������� � ������� � ������� �� RoomInfo
            serverDisplay.Initialize(roomInfo);
        }
        RefreshServerList();
    }


    private void OnDisable()
    {
        // �������� ���������� ������ � PhotonNetwork.Callbacks ��� ������ �� �����
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    private void RefreshServerList()
    {
        // �������� ������������ ������� � ������
        foreach (Transform child in serverListContent)
        {
            Destroy(child.gameObject);
        }

        // �������� ��������� ��� ����������
        Hashtable expectedCustomRoomProperties = new Hashtable
        {
            { "isOpen", true } // ������: ������ �������� �����
        };

        // �������� ��������� ������� Photon � ������ ����������
    }
}

[System.Serializable]
public class ServerData
{
    public string serverName;
    public string ipAddress;
    // ������ ��������� �������, ��������, ���������� ������� � �. �.
}
