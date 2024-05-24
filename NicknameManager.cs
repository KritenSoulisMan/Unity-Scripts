using UnityEngine;
using UnityEngine.UI;

public class NicknameManager : MonoBehaviour
{
    public Canvas nicknameCanvas; // Ссылка на Canvas с InputField.
    public InputField inputField; // Ссылка на InputField для ввода никнейма.

    private string playerName; // Переменная для хранения никнейма.

    // Вызывается при нажатии на кнопку "Сохранить" в InputField.
    public void SaveNickname()
    {
        playerName = inputField.text;
        PlayerPrefs.SetString("PlayerName", playerName); // Сохраните никнейм в PlayerPrefs.
        HideNicknameInput(); // Скройте InputField.
    }

    // Метод для отображения InputField для изменения никнейма.
    public void ShowNicknameInput()
    {
        inputField.text = PlayerPrefs.GetString("PlayerName", ""); // Загрузите сохраненный никнейм.
        nicknameCanvas.gameObject.SetActive(true); // Покажите Canvas с InputField.
    }

    // Метод для скрытия InputField.
    public void HideNicknameInput()
    {
        nicknameCanvas.gameObject.SetActive(false); // Скройте Canvas с InputField.
    }
}
