using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject ExitSettings;

    public GameObject SettingsPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ExitButton()
    {
        SettingsPanel.SetActive(false);
    }
}
