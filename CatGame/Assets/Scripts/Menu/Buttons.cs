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
    }

    public void PlayButton()
    {
        // Sprawdzamy, czy gracz gra³ wczeœniej
        if (PlayerPrefs.GetInt("HasPlayedBefore", 0) == 1)
        {
            // Pobieramy zapisany poziom
            int savedLevel = PlayerPrefs.GetInt("SavedLevel", 3); // Domyœlnie 3, jeœli nie ma zapisu
            SceneManager.LoadScene(savedLevel);
        }
        else
        {
            // Jeœli to pierwsza gra, przechodzimy do tutorialu
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
