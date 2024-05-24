using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject settings;
    public GameObject serverlist;
    public GameObject help;
    public GameObject exitTab;
    public GameObject social;
    public GameObject lob;

    void Start()
    {
        mainmenu.SetActive(true);
        settings.SetActive(false);
        serverlist.SetActive(false);
        help.SetActive(false);
        exitTab.SetActive(false);
        social.SetActive(false);
        lob.SetActive(false);
    }

    public void Menu()
    {
        mainmenu.SetActive(true);
        settings.SetActive(false);
        serverlist.SetActive(false);
        help.SetActive(false);
        exitTab.SetActive(false);
        social.SetActive(false);
        lob.SetActive(false);
    }

    public void Settings()
    {
        mainmenu.SetActive(false);
        settings.SetActive(true);
        serverlist.SetActive(false);
        help.SetActive(false);
        exitTab.SetActive(false);
        social.SetActive(false);
        lob.SetActive(false);
    }

    public void Serverlist()
    {
        mainmenu.SetActive(false);
        settings.SetActive(false);
        serverlist.SetActive(true);
        help.SetActive(false);
        exitTab.SetActive(false);
        social.SetActive(false);
        lob.SetActive(false);
    }

    public void Help()
    {
        mainmenu.SetActive(false);
        settings.SetActive(false);
        serverlist.SetActive(false);
        help.SetActive(true);
        exitTab.SetActive(false);
        social.SetActive(false);
        lob.SetActive(false);
    }

    public void ExitTab()
    {
        mainmenu.SetActive(false);
        settings.SetActive(false);
        serverlist.SetActive(false);
        help.SetActive(false);
        exitTab.SetActive(true);
        social.SetActive(false);
        lob.SetActive(false);
    }

    public void Social()
    {
        mainmenu.SetActive(false);
        settings.SetActive(false);
        serverlist.SetActive(false);
        help.SetActive(false);
        exitTab.SetActive(false);
        social.SetActive(true);
        lob.SetActive(false);
    }

    public void Lobby()
    {
        mainmenu.SetActive(false);
        settings.SetActive(false);
        serverlist.SetActive(false);
        help.SetActive(false);
        exitTab.SetActive(false);
        social.SetActive(false);
        lob.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
