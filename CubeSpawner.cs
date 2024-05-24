using Photon.Pun;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private PhotonView PV;

    public GameObject cubePrefab;
    public Transform handTransform;
    public int maxCubes = 5; // ������������ ���������� �����

    private int currentCubes = 0; // ������� ���������� �����
    private GameObject spawnedCube;

    void Start()
    {
        // �������������� handTransform, ��������, ����� ��� ��������� Transform �� �������,
        // �� ������� ��������� ������
        handTransform = transform; // ������, �����������, ��� ������ ��������� �� ��� �� �������, ��� � ��������� Transform
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
