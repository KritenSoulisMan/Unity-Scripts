using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class RoomListManager : MonoBehaviourPunCallbacks
{
    public GameObject roomInLobbyPanel;
    public Text messageText;

    private Dictionary<string, RoomInfo> myRoomList = new Dictionary<string, RoomInfo>();

    public void Start()
    {
        // ������������� ������� � �������� �� ������� PhotonNetwork
        PhotonNetwork.AddCallbackTarget(this);
    }

    public void OnDestroy()
    {
        // ������������ �� ������� ��� ����������� �������
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("roomListUpdated");

        // ������� ������������ UI ������ ����� �����������
        GameObject[] pr = GameObject.FindGameObjectsWithTag("CustomRoom");
        foreach (var r in pr)
        {
            Destroy(r);
        }

        foreach (var r in roomList)
        {
            // ���������� �������, ��� ������� ������� ����� ��������� ��� ������� �� myRoomList
            if (!r.IsOpen || !r.IsVisible || r.RemovedFromList)
            {
                if (myRoomList.ContainsKey(r.Name))
                {
                    myRoomList.Remove(r.Name);
                }
                continue;
            }

            if (myRoomList.ContainsKey(r.Name))
            {
                myRoomList[r.Name] = r;
            }
            else
            {
                myRoomList.Add(r.Name, r);
            }
        }

        foreach (var r in myRoomList.Values)
        {
            // �������� UI ��� �������
            UpdateRoomList(r.Name);
        }

        Debug.Log("===roomList count:" + roomList.Count + "===myRoomList count:" + myRoomList.Count);
        messageText.text = "===roomList count:" + roomList.Count + "===myRoomList count:" + myRoomList.Count;
    }

    public void UpdateRoomList(string name)
    {
        // �������� UI ��� ������� �� ������ �������������� ���������� �������
        GameObject go = Instantiate(Resources.Load("CustomRoom") as GameObject);
        go.transform.parent = roomInLobbyPanel.transform;
        go.transform.localScale = Vector3.one;
        go.name = name;
        go.transform.Find("RoomName").GetComponent<Text>().text = name;

        // �������� ������� ������ �������
        go.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            this.ChooseRoom(go.name);
        });
    }

    public void ChooseRoom(string roomName)
    {
        // �������� ��� ������ �������, ����� �������� ���� ������
        Debug.Log("Selected room: " + roomName);
    }

    public List<RoomInfo> GetAvailableRooms(int maxPlayers, int minPlayers)
    {
        List<RoomInfo> availableRooms = new List<RoomInfo>();

        foreach (var room in myRoomList.Values)
        {
            // ������� ����������: ������� ������ ��������������� �������� ������������
            if (room.MaxPlayers >= maxPlayers && room.PlayerCount >= minPlayers)
            {
                availableRooms.Add(room);
            }
        }

        return availableRooms;
    }
}
