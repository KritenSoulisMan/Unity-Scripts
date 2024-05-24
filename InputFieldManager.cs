using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    public InputField inputField;

    private void Start()
    {
        // Добавляем слушатель события "On End Edit" для InputField.
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    // Обработчик события "On End Edit".
    private void OnEndEdit(string text)
    {
        // Проверяем, была ли нажата клавиша "Enter" (код 13 - Enter).
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            // Клавиша "Enter" была нажата, но мы не выполняем никаких действий.
            // Можете добавить здесь свою логику, если необходимо.
        }
        else
        {
            // Здесь выполняем действия, связанные с завершением редактирования,
            // только если Enter не был нажат.
            Debug.Log("Завершение редактирования текста: " + text);
        }
    }
}
