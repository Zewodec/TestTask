using UnityEngine;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        EventManager.OnUpdateTextUI.AddListener(UpdateScoreText);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + PlayerStats.getPoints();
    }
}
