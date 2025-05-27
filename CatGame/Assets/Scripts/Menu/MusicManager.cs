using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicSource;
    private bool isMuted = false;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        musicSource.mute = isMuted;
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        musicSource.mute = isMuted;
        PlayerPrefs.SetInt("MusicMuted", isMuted ? 1 : 0);
    }

}
