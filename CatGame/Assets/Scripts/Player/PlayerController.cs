using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public int playerScore = 0;

    private Rigidbody2D rb;
    public TMP_Text pointsText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LoadProgress(); // Wczytaj zapisane punkty
        UpdatePointsUI();
    }

    public void Move(float horizontalInput)
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    public void Jump()
    {
        if (rb == null) return;

        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void GainPoint()
    {
        playerScore++;
        Debug.Log("Zdobyłeś punkt! Aktualny wynik: " + playerScore);
        UpdatePointsUI();
    }

    private void UpdatePointsUI()
    {
        if (pointsText != null)
        {
            pointsText.text = playerScore.ToString();
        }
    }

    private void LoadProgress()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel != 2) // Nie wczytujemy punktów w tutorialu
        {
            playerScore = PlayerPrefs.GetInt("SavedScore", 0);
        }
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetInt("SavedScore", playerScore);
        PlayerPrefs.SetInt("SavedLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
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
            PlayerPrefs.SetInt("SavedScore", 0); // Zerujemy punkty po tutorialu
            PlayerPrefs.SetInt("SavedLevel", 3); // Ustawiamy poziom 1 jako startowy po tutorialu
            PlayerPrefs.Save();
            SceneManager.LoadScene(3); // Przejście do poziomu 1
        }
        else
        {
            SaveProgress(); // Zapisujemy postęp
            SceneManager.LoadScene(nextLevel);
        }
    }
}
