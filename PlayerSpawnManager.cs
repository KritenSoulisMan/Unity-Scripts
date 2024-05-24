using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public GameObject playerPrefab; // ������ ������.

    private void Start()
    {
        // ������� ������ � ��������� �����������.
        Vector3 spawnPosition = new Vector3(0f, 0f, 100f);
        Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }
}
