using UnityEngine;

public class SomeGameScript : MonoBehaviour
{
    private PlayerSettingsManager playerSettingsManager;

    private void Start()
    {
        // Найдите объект с PlayerSettingsManager в сцене.
        playerSettingsManager = FindObjectOfType<PlayerSettingsManager>();

        if (playerSettingsManager != null)
        {
            // Получите никнейм игрока.
            string playerName = playerSettingsManager.GetPlayerName();

            // Используйте playerName в игре.
        }
        else
        {
            Debug.LogError("PlayerSettingsManager not found in the scene!");
        }
    }
}
