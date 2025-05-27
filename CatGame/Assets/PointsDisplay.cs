using UnityEngine;
using TMPro;

public class PointsDisplay : MonoBehaviour
{
    public TMP_Text pointsText;

    void Start()
    {
        int savedPoints = PlayerPrefs.GetInt("SavedScore", 0);
        pointsText.text = savedPoints.ToString();
    }
}
