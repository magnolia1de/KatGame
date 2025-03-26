using UnityEngine;

public class ScratcherCheck : MonoBehaviour
{
    public string correctScratcherTag = "CorrectScratcher";
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
            Debug.Log("Kot dotar� do w�a�ciwego drapaka! Koniec poziomu!");
            playerController.GainPoint();
        }
        else if (other.CompareTag("Scratcher"))
        {
            Debug.Log("To nie jest w�a�ciwy drapak!");
            playerController.LoseLife();
        }
    }
}
