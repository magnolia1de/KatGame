using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    public TMP_Text pointsText;
    public bool canMove = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            // Poza tutorialem wczytujemy punkty z ScoreManager
            UpdatePointsUI();
        }
        else
        {
            // W tutorialu punkty są zerowane
            ScoreManager.ResetScore();
            UpdatePointsUI();
        }
    }

    public void Move(float horizontalInput)
    {
        if (!canMove) return;
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    public void Jump()
    {
        if (!canMove) return;

        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void GainPoint()
    {
        ScoreManager.AddPoints(1);
        Debug.Log("Zdobyłeś punkt! Aktualny wynik: " + ScoreManager.GetScore());
        UpdatePointsUI();
    }

    private void UpdatePointsUI()
    {
        if (pointsText != null)
        {
            pointsText.text = ScoreManager.GetScore().ToString();
        }
    }

    public void LoseGame()
    {
        Debug.Log("Przegrałeś!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelFinish()
    {
        Debug.Log("🎉 Gratulacje! Ukończyłeś poziom!");

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;

        if (currentLevel == 2) // Jeśli to był tutorial
        {
            Debug.Log("✅ Ukończyłeś tutorial! Przechodzę do poziomu 1.");
            PlayerPrefs.SetInt("TutorialCompleted", 1);
            ScoreManager.ResetScore(); // Zerujemy punkty
            PlayerPrefs.SetInt("SavedLevel", 3);
            PlayerPrefs.Save();
            SceneManager.LoadScene(3);
        }
        else
        {
            SaveProgress(); // Zapisujemy poziom, punkty są już w ScoreManager
            SceneManager.LoadScene(nextLevel);
        }
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetInt("SavedLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }
}
