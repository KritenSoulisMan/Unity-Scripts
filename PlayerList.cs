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
        // Вызывается, когда новый игрок присоединяется к лобби.
        // Обновляем список игроков при входе нового игрока.
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // Вызывается, когда игрок покидает лобби.
        // Обновляем список игроков при выходе игрока.
        UpdatePlayerList();
    }

    private void UpdatePlayerList()
    {
        // Получаем список всех игроков в лобби.
        Player[] players = PhotonNetwork.PlayerList;

        // Обновляем текстовый элемент с списком игроков.
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