using UnityEngine;
using UnityEngine.SceneManagement; // Potrzebne do zmiany sceny

public class GameManager : MonoBehaviour
{
    public void LevelFinish()
    {
        Debug.Log("🎉 Gratulacje! Ukończyłeś poziom!");

        int currentLevel = SceneManager.GetActiveScene().buildIndex; // Pobiera aktualny poziom
        int nextLevel = currentLevel + 1;

        // Sprawdzenie, czy to tutorial (zakładam, że poziom 2 to tutorial)
        if (currentLevel == 2)
        {
            Debug.Log("✅ Ukończyłeś tutorial! Przechodzę do poziomu 1.");
            PlayerPrefs.SetInt("TutorialCompleted", 1); // Zapisanie, że tutorial został ukończony
            SceneManager.LoadScene(3); // Przejście do poziomu 3 (czyli poziomu 1)
        }
        else
        {
            Debug.Log($"🔜 Przechodzę do poziomu {nextLevel}.");
            SceneManager.LoadScene(nextLevel); // Przejście do następnego poziomu
        }
    }
}
