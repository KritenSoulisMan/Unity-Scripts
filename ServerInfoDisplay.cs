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

        // Установите тексты в соответствии с информацией о сервере
        serverNameText.text = roomInfo.Name;
        playerCountText.text = $"{roomInfo.PlayerCount}/{roomInfo.MaxPlayers}";
        lobbyStatusText.text = roomInfo.IsOpen ? "Открыто" : "Закрыто";

        // Назначьте кнопке функцию для присоединения к серверу
        joinButton.onClick.AddListener(JoinServer);
    }

    private void JoinServer()
    {
        // Реализуйте здесь ваш код для присоединения к серверу
        // Например, используйте PhotonNetwork.JoinRoom(roomInfo.Name);
    }
}
