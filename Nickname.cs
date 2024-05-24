using UnityEngine;

public class Nickname : MonoBehaviour
{
    public Transform target; // Ссылка на трансформ игрока, над которым будет отображаться никнейм.

    private void LateUpdate()
    {
        if (target != null)
        {
            // Позиция никнейма будет следовать за игроком.
            transform.position = target.position + Vector3.up * 2f; // Вы можете настроить высоту никнейма.
        }
    }
}
