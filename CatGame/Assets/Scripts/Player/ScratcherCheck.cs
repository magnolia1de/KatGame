using UnityEngine;

public class ScratcherCheck : MonoBehaviour
{
    public string correctScratcherTag = "GoodExit";
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("Nie znaleziono PlayerController!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(correctScratcherTag))
        {
            Debug.Log("Kot dotar³ do w³aœciwego drapaka! Koniec poziomu!");
            playerController.LevelFinish();
        }
        else if (other.CompareTag("BadExit"))
        {
            Debug.Log("To nie jest w³aœciwy drapak!");
            playerController.LoseGame();
        }
    }
}
