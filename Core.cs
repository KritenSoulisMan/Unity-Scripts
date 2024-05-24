using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Core : MonoBehaviourPunCallbacks
{
    public static Core Instance; // ����������� ������ �� ���� ��� ������� �� ������ ��������.

    private bool isServerRunning = false;
    private bool isLeavingGame = false; // �������� ��� � ����� ������� Core.cs

    private void Awake()
    {
        if (Instance == null) // ������������� ����������� ������ �� ��� ����.
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // ������� �������� ����, ���� ����� ��� ����������.
        }

        DontDestroyOnLoad(gameObject); // �� ���������� ������ � ���� �������� ��� �������� ����� �������.
    }

    private void Start()
    {
        isServerRunning = PhotonNetwork.IsMasterClient; // ����������, �������� �� �� ������ �������.

        if (isServerRunning) // ��������� ��������, ��������� � ������ ������� (��������, �������� �������� �� �����).
        {

        }
        else // ��������� ��������, ��������� � ������� ������� (��������, ����������� ����������).
        {

        }
    }

    public void JoinServer()
    {
        PhotonNetwork.JoinRandomRoom(); // �������������� � ������������� �������.
    }

    public void LeaveServer()
    {
        PhotonNetwork.LeaveRoom(); // �������� ������� ������.
    }

    public override void OnJoinedRoom() // Callback-�����, ���������� ��� �������� ����� �� ������.
    {
        if (isServerRunning) // ��������� ��������, ��������� � ������ �������.
        {

        }
        else // ��������� ��������, ��������� � ������� �������.
        {

        }
    }

    // Callback-�����, ���������� ��� ������ �� �������.
    public override void OnLeftRoom()
    {
        if (isLeavingGame) // ��������� �������� ��� ������ �� ���� (��������, ������� � ������� ����).
        {
            SceneManager.LoadScene("MainMenu");
        }
        else // ��������� �������� ��� ������ �� ������� (��������, ������� � ����� ��� ������ �����).
        {
            isLeavingGame = true;
            PhotonNetwork.LeaveRoom();
        }
    }
}
