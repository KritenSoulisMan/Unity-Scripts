using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerList : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    public GameObject Panel;

    private void Start()
    {
        GameObject player = Instantiate(PlayerPrefab);
        player.transform.parent = Panel.transform;
        //player.GetComponent<Text>().text = nick;
        PhotonView photonView = player.GetComponent<PhotonView>();
        UpdatePlayerList();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // ����������, ����� ����� ����� �������������� � �����.
        // ��������� ������ ������� ��� ����� ������ ������.
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // ����������, ����� ����� �������� �����.
        // ��������� ������ ������� ��� ������ ������.
        UpdatePlayerList();
    }

    private void UpdatePlayerList()
    {
        // �������� ������ ���� ������� � �����.
        Player[] players = PhotonNetwork.PlayerList;

        // ��������� ��������� ������� � ������� �������.
        string playerList = "";
        foreach (Player player in players)
        {
            if (player.IsMasterClient)
            {
                playerList += "<Host> " + player.NickName + "\n";
            }
            else
            {
                playerList += "<Player> " + player.NickName + "\n";
            }
        }
    }
}