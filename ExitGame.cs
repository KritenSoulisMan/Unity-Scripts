using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("Loading");
        }
    }
}
