using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public GameObject playerPrefab; // Префаб игрока.

    private void Start()
    {
        // Создаем игрока в указанных координатах.
        Vector3 spawnPosition = new Vector3(0f, 0f, 100f);
        Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }
}
