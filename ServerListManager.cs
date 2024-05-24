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

        // Создайте префабы для каждого сервера
        foreach (RoomInfo roomInfo in availableRooms)
        {
            GameObject serverItem = Instantiate(serverPrefab, serverListContent);
            ServerInfoDisplay serverDisplay = serverItem.GetComponent<ServerInfoDisplay>();

            // Инициализируйте информацию о сервере с данными из RoomInfo
            serverDisplay.Initialize(roomInfo);
        }
        RefreshServerList();
    }


    private void OnDisable()
    {
        // Отмените назначение метода в PhotonNetwork.Callbacks при выходе из сцены
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    private void RefreshServerList()
    {
        // Очистите существующие серверы в списке
        foreach (Transform child in serverListContent)
        {
            Destroy(child.gameObject);
        }

        // Создайте параметры для фильтрации
        Hashtable expectedCustomRoomProperties = new Hashtable
        {
            { "isOpen", true } // Фильтр: только открытые лобби
        };

        // Получите доступные серверы Photon с учетом фильтрации
    }
}

[System.Serializable]
public class ServerData
{
    public string serverName;
    public string ipAddress;
    // Другие параметры сервера, например, количество игроков и т. д.
}
