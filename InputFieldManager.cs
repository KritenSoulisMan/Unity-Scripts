using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    public InputField inputField;

    private void Start()
    {
        // ��������� ��������� ������� "On End Edit" ��� InputField.
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    // ���������� ������� "On End Edit".
    private void OnEndEdit(string text)
    {
        // ���������, ���� �� ������ ������� "Enter" (��� 13 - Enter).
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            // ������� "Enter" ���� ������, �� �� �� ��������� ������� ��������.
            // ������ �������� ����� ���� ������, ���� ����������.
        }
        else
        {
            // ����� ��������� ��������, ��������� � ����������� ��������������,
            // ������ ���� Enter �� ��� �����.
            Debug.Log("���������� �������������� ������: " + text);
        }
    }
}
