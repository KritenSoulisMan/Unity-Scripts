using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Core : MonoBehaviourPunCallbacks
{
    public static Core Instance; // Статическая ссылка на ядро для доступа из других скриптов.

    private bool isServerRunning = false;
    private bool isLeavingGame = false; // Добавьте это в вашем скрипте Core.cs

    private void Awake()
    {
        if (Instance == null) // Устанавливаем статическую ссылку на это ядро.
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Удаляем дубликат ядра, если такой уже существует.
        }

        DontDestroyOnLoad(gameObject); // Не уничтожаем объект с этим скриптом при переходе между сценами.
    }

    private void Start()
    {
        isServerRunning = PhotonNetwork.IsMasterClient; // Определяем, являемся ли мы хостом сервера.

        if (isServerRunning) // Выполняем действия, связанные с хостом сервера (например, создание объектов на сцене).
        {

        }
        else // Выполняем действия, связанные с обычным игроком (например, отображение интерфейса).
        {

        }
    }

    public void JoinServer()
    {
        PhotonNetwork.JoinRandomRoom(); // Присоединяемся к существующему серверу.
    }

    public void LeaveServer()
    {
        PhotonNetwork.LeaveRoom(); // Покидаем текущий сервер.
    }

    public override void OnJoinedRoom() // Callback-метод, вызывается при успешном входе на сервер.
    {
        if (isServerRunning) // Выполняем действия, связанные с хостом сервера.
        {

        }
        else // Выполняем действия, связанные с обычным игроком.
        {

        }
    }

    // Callback-метод, вызывается при выходе из сервера.
    public override void OnLeftRoom()
    {
        if (isLeavingGame) // Выполняем действия при выходе из игры (например, возврат в главное меню).
        {
            SceneManager.LoadScene("MainMenu");
        }
        else // Выполняем действия при выходе из сервера (например, переход в лобби или другую сцену).
        {
            isLeavingGame = true;
            PhotonNetwork.LeaveRoom();
        }
    }
}
