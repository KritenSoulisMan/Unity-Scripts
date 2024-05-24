using UnityEngine;

public class PlayerSettingsManager : MonoBehaviour
{
    private PlayerSettings playerSettings;

    private void Start()
    {
        LoadPlayerSettings();
        LoadPlayerName(); // Загружаем никнейм игрока при старте.
    }

    public void SavePlayerSettings()
    {
        PlayerPrefs.SetString("PlayerSettings", JsonUtility.ToJson(playerSettings));
    }

    public void LoadPlayerSettings()
    {
        string settingsJson = PlayerPrefs.GetString("PlayerSettings");
        playerSettings = JsonUtility.FromJson<PlayerSettings>(settingsJson);

        if (playerSettings == null)
        {
            playerSettings = new PlayerSettings();
        }
    }

    public string GetPlayerName()
    {
        return playerSettings.playerName;
    }

    public void SetPlayerName(string newName)
    {
        playerSettings.playerName = newName;
        SavePlayerSettings();
    }

    // Новый метод для загрузки никнейма игрока.
    private void LoadPlayerName()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "");
        SetPlayerName(playerName);
    }
}
