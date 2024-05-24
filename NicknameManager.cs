using UnityEngine;
using UnityEngine.UI;

public class NicknameManager : MonoBehaviour
{
    public Canvas nicknameCanvas; // ������ �� Canvas � InputField.
    public InputField inputField; // ������ �� InputField ��� ����� ��������.

    private string playerName; // ���������� ��� �������� ��������.

    // ���������� ��� ������� �� ������ "���������" � InputField.
    public void SaveNickname()
    {
        playerName = inputField.text;
        PlayerPrefs.SetString("PlayerName", playerName); // ��������� ������� � PlayerPrefs.
        HideNicknameInput(); // ������� InputField.
    }

    // ����� ��� ����������� InputField ��� ��������� ��������.
    public void ShowNicknameInput()
    {
        inputField.text = PlayerPrefs.GetString("PlayerName", ""); // ��������� ����������� �������.
        nicknameCanvas.gameObject.SetActive(true); // �������� Canvas � InputField.
    }

    // ����� ��� ������� InputField.
    public void HideNicknameInput()
    {
        nicknameCanvas.gameObject.SetActive(false); // ������� Canvas � InputField.
    }
}
