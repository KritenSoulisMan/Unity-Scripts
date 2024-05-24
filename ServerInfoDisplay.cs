using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class ServerInfoDisplay : MonoBehaviour
{
    public Text serverNameText;
    public Text playerCountText;
    public Text lobbyStatusText;
    public Button joinButton;

    private RoomInfo roomInfo;

    public void Initialize(RoomInfo roomInfo)
    {
        this.roomInfo = roomInfo;

        // ���������� ������ � ������������ � ����������� � �������
        serverNameText.text = roomInfo.Name;
        playerCountText.text = $"{roomInfo.PlayerCount}/{roomInfo.MaxPlayers}";
        lobbyStatusText.text = roomInfo.IsOpen ? "�������" : "�������";

        // ��������� ������ ������� ��� ������������� � �������
        joinButton.onClick.AddListener(JoinServer);
    }

    private void JoinServer()
    {
        // ���������� ����� ��� ��� ��� ������������� � �������
        // ��������, ����������� PhotonNetwork.JoinRoom(roomInfo.Name);
    }
}
