using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviourPunCallbacks
{
    // ���������� ��� �����.
    public InputField lobbyNameInputField;
    public Dropdown lobbyAvailabilityDropdown;
    public Text lobbyStatusText;

    private bool isLobbyOpen = true; // �� ��������� ����� �������.

    private void Start()
    {
        // �������� ���������� ��������� �������� DropDown ��� ����������� �����.
        lobbyAvailabilityDropdown.onValueChanged.AddListener(OnLobbyAvailabilityDropdownValueChanged);

        // �������� ������� ��� ������� �����.
        CreateRoom();

        // �������� ������ �����.
        UpdateLobbyStatus();
    }

    public void OnLobbyAvailabilityDropdownValueChanged(int value)
    {
        // 0 - �������, 1 - �������
        isLobbyOpen = value == 0; // ���� ������� ����� "�������", �� ����� �������.

        // ��� ��������� ����������� �����, �������� ��� ������.
        UpdateLobbyStatus();
    }

    private void UpdateLobbyStatus()
    {
        // ������������� ����������� ������� �� ������ �������� isLobbyOpen.
        RoomOptions roomOptions = new RoomOptions
        {
            IsOpen = isLobbyOpen, // ������������� ����������� �������.
            MaxPlayers = 5, // ������������ ���������� �������.
        };

        // ������������ ������� � ������ �����������.
        PhotonNetwork.CreateRoom(lobbyNameInputField.text, roomOptions);

        // �������� ���� lobbyStatusText � ����� �������� �����.
        lobbyStatusText.text = isLobbyOpen ? "�������" : "�������";

        // ������ �������� ��� ��������� ������� ����� (���� ����).
    }

    public void CreateRoom()
    {
        // �������� ������� ��� ������� �����.
        RoomOptions roomOptions = new RoomOptions
        {
            IsOpen = isLobbyOpen, // ������������� ����������� �������.
            MaxPlayers = 5, // ������������ ���������� �������.
        };

        PhotonNetwork.CreateRoom(lobbyNameInputField.text, roomOptions);
    }
}
