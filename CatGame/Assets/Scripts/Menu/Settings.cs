using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GameObject ExitSettings;

    public GameObject SettingsPanel;
    public GameObject MenuButton;

    private void Start()
    {
        SettingsPanel.SetActive(false);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        SettingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
    }

    public void SendEmailToDev()
    {
        string email = "u31_magsat_waw@technischools.com";
        string subject = EscapeURL("Kontakt z tw�rc� gry");
        string body = EscapeURL("Cze��,\n\nChcia�bym zg�osi� uwag� dotycz�c� gry...");

        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }

    string EscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }


}
