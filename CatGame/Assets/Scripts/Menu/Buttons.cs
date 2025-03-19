using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject Play;
    public GameObject Settings;
    public GameObject Shop;

    public GameObject SettingsPanel;

    void Start()
    {
        SettingsPanel.SetActive(false);

        //PlayerPrefs.SetInt("HasPlayedBefore", 0);
        //PlayerPrefs.Save();
    }

    public void PlayButton()
    {
        if (PlayerPrefs.GetInt("HasPlayedBefore") == 1)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(2);
            PlayerPrefs.SetInt("HasPlayedBefore", 1);
            PlayerPrefs.Save();
        }
    }

    public void SettingsButton()
    {
        SettingsPanel.SetActive(true);
    }

    public void ShopButton()
    {
        SceneManager.LoadScene(1);
    }
}
