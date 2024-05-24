using UnityEngine;

public class SomeGameScript : MonoBehaviour
{
    private PlayerSettingsManager playerSettingsManager;

    private void Start()
    {
        // ������� ������ � PlayerSettingsManager � �����.
        playerSettingsManager = FindObjectOfType<PlayerSettingsManager>();

        if (playerSettingsManager != null)
        {
            // �������� ������� ������.
            string playerName = playerSettingsManager.GetPlayerName();

            // ����������� playerName � ����.
        }
        else
        {
            Debug.LogError("PlayerSettingsManager not found in the scene!");
        }
    }
}
