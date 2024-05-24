using UnityEngine;

public class Nickname : MonoBehaviour
{
    public Transform target; // ������ �� ��������� ������, ��� ������� ����� ������������ �������.

    private void LateUpdate()
    {
        if (target != null)
        {
            // ������� �������� ����� ��������� �� �������.
            transform.position = target.position + Vector3.up * 2f; // �� ������ ��������� ������ ��������.
        }
    }
}
