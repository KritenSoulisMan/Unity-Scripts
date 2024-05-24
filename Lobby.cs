using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviourPunCallbacks
{
    // Переменные для лобби.
    public InputField lobbyNameInputField;
    public Dropdown lobbyAvailabilityDropdown;
    public Text lobbyStatusText;

    private bool isLobbyOpen = true; // По умолчанию лобби открыто.

    private void Start()
    {
        // Добавьте обработчик изменения значения DropDown для доступности лобби.
        lobbyAvailabilityDropdown.onValueChanged.AddListener(OnLobbyAvailabilityDropdownValueChanged);

        // Создайте комнату при запуске лобби.
        CreateRoom();

        // Обновите статус лобби.
        UpdateLobbyStatus();
    }

    public void OnLobbyAvailabilityDropdownValueChanged(int value)
    {
        // 0 - Открыто, 1 - Закрыто
        isLobbyOpen = value == 0; // Если выбрана опция "Открыто", то лобби открыто.

        // При изменении доступности лобби, обновите его статус.
        UpdateLobbyStatus();
    }

    private void UpdateLobbyStatus()
    {
        // Устанавливаем доступность комнаты на основе значения isLobbyOpen.
        RoomOptions roomOptions = new RoomOptions
        {
            IsOpen = isLobbyOpen, // Устанавливаем доступность комнаты.
            MaxPlayers = 5, // Максимальное количество игроков.
        };

        // Пересоздайте комнату с новыми настройками.
        PhotonNetwork.CreateRoom(lobbyNameInputField.text, roomOptions);

        // Обновите поле lobbyStatusText с новым статусом лобби.
        lobbyStatusText.text = isLobbyOpen ? "Открыто" : "Закрыто";

        // Другие действия при изменении статуса лобби (если есть).
    }

    public void CreateRoom()
    {
        // Создайте комнату при запуске лобби.
        RoomOptions roomOptions = new RoomOptions
        {
            IsOpen = isLobbyOpen, // Устанавливаем доступность комнаты.
            MaxPlayers = 5, // Максимальное количество игроков.
        };

        PhotonNetwork.CreateRoom(lobbyNameInputField.text, roomOptions);
    }
}
