using Photon.Pun;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private PhotonView PV;

    public GameObject cubePrefab;
    public Transform handTransform;
    public int maxCubes = 5; // Максимальное количество кубов

    private int currentCubes = 0; // Текущее количество кубов
    private GameObject spawnedCube;

    void Start()
    {
        // Инициализируем handTransform, например, найдя его компонент Transform на объекте,
        // на котором находится скрипт
        handTransform = transform; // Пример, предполагая, что скрипт находится на том же объекте, что и компонент Transform
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && PV.IsMine)
        {
            if (currentCubes < maxCubes)
            {
                SpawnCube();
                currentCubes++;
            }
        }
    }

    void SpawnCube()
    {
        if (handTransform != null)
        {
            spawnedCube = PhotonNetwork.Instantiate(cubePrefab.name, handTransform.position, handTransform.rotation);
            spawnedCube.transform.SetParent(null);
        }
        else
        {
            Debug.LogError("handTransform is not initialized!");
        }
    }

}
