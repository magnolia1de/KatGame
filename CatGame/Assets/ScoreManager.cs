using UnityEngine;

public static class ScoreManager
{
    private const string ScoreKey = "SavedScore";

    // Pobiera aktualny wynik
    public static int GetScore()
    {
        return PlayerPrefs.GetInt(ScoreKey, 0);
    }

    // Ustawia wynik na konkretn¹ wartoœæ
    public static void SetScore(int newScore)
    {
        PlayerPrefs.SetInt(ScoreKey, newScore);
        PlayerPrefs.Save();
    }

    // Dodaje punkty
    public static void AddPoints(int amount)
    {
        int current = GetScore();
        SetScore(current + amount);
    }

    // Odejmuje punkty
    public static bool SubtractPoints(int amount)
    {
        int current = GetScore();
        if (current >= amount)
        {
            SetScore(current - amount);
            return true;
        }
        return false; // Za ma³o punktów
    }

    // Resetuje punkty
    public static void ResetScore()
    {
        SetScore(0);
    }
}
