using UnityEngine;
using TMPro;
using Unity.Cinemachine;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    public bool isTutorial = true; // Jeśli true, uruchamia tutorial
    public TMP_Text tutorialText; // UI z tekstem
    public GameObject tutorialPanel; // Tło dla tekstu

    public CinemachineVirtualCamera cinemachineCamera;
    public Transform player; // Gracz
    public Transform pointsUI; // UI punktów
    public Transform jumpButton; // Przycisk skoku
    public Transform moveButton; // Przycisk ruchu
    public Transform scratchPost; // Drapak (koniec poziomu)

    private void Start()
    {
        Debug.Log("cinemachineCamera: " + cinemachineCamera); // Sprawdź, czy kamera jest przypisana

        if (cinemachineCamera == null)
        {
            Debug.LogError("❌ Cinemachine Camera NIE jest przypięta! Przypisz ją w Inspectorze.");
            return; // Zatrzymujemy kod, jeśli kamera nie jest przypięta
        }

        if (isTutorial)
        {
            StartCoroutine(RunTutorial());
        }
        else
        {
            tutorialPanel.SetActive(false); // Ukryj UI jeśli to nie jest tutorial
        }
    }

    private IEnumerator RunTutorial()
    {
        tutorialPanel.SetActive(true);

        // 1. Wprowadzenie
        ShowMessage("Witaj! To jest krótki samouczek.");
        yield return new WaitForSeconds(2f);

        // 2. Pokaż przycisk ruchu
        MoveCamera(moveButton.position);
        ShowMessage("To przycisk do poruszania się.");
        yield return new WaitForSeconds(3f);

        // 3. Pokaż przycisk skoku
        MoveCamera(jumpButton.position);
        ShowMessage("Ten przycisk pozwala Ci skakać.");
        yield return new WaitForSeconds(3f);

        // 4. Pokaż punkty
        MoveCamera(pointsUI.position);
        ShowMessage("Tu widzisz swoje punkty.");
        yield return new WaitForSeconds(3f);

        // 5. Pokaż cel gry
        MoveCamera(scratchPost.position);
        ShowMessage("Dojdź do drapaka, aby ukończyć poziom!");
        yield return new WaitForSeconds(3f);

        // 6. Powrót na gracza i koniec tutoriala
        MoveCamera(player.position);
        ShowMessage("Teraz możesz grać! Powodzenia!");
        yield return new WaitForSeconds(2f);

        tutorialPanel.SetActive(false);
        cinemachineCamera.Follow = player; // Przywróć śledzenie gracza
    }

    private void ShowMessage(string message)
    {
        tutorialText.text = message;
    }

    private void MoveCamera(Vector3 targetPosition)
    {
        if (cinemachineCamera != null)
        {
            cinemachineCamera.Follow = null; // Odłącz gracza
            cinemachineCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, cinemachineCamera.transform.position.z);
        }
        else
        {
            Debug.LogError("❌ Błąd: cinemachineCamera jest NULL!");
        }
    }
}
